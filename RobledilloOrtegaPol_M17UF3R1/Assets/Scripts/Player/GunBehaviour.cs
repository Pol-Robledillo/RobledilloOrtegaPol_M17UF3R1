using System.Collections;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject hitEffect;
    public NewPlayerController playerController;
    public GameObject raycastOrigin;
    public float maxDistance = 100f;
    public GameObject mainCamera;
    public int damage = 10;

    public void Start()
    {
        mainCamera = playerController.activeCamera;
    }

    public void Shoot()
    {
        Vector3 rayOrigin = mainCamera.transform.position;
        Vector3 rayDirection = mainCamera.transform.forward;
        Ray cameraRay = new Ray(rayOrigin, rayDirection);
        RaycastHit cameraHit;

        if (Physics.Raycast(cameraRay, out cameraHit, maxDistance))
        {
            Debug.DrawLine(rayOrigin, cameraHit.point, Color.red);

            if (raycastOrigin != null)
            {
                Vector3 secondRayDirection = (cameraHit.point - raycastOrigin.transform.position).normalized;
                Ray secondRay = new Ray(raycastOrigin.transform.position, secondRayDirection);
                RaycastHit secondHit;

                if (Physics.Raycast(secondRay, out secondHit, maxDistance))
                {
                    StartCoroutine(GenerateHitEffect(secondHit));
                    Debug.DrawLine(raycastOrigin.transform.position, secondHit.point, Color.blue);
                    if (secondHit.collider.CompareTag("Enemy"))
                    {
                        Debug.Log("Hit enemy: " + secondHit.collider.name);
                        secondHit.collider.GetComponent<IDamageable>().TakeDamage(damage);
                    }
                }
            }
        }
    }
    public IEnumerator GenerateHitEffect(RaycastHit secondHit)
    {
        yield return new WaitForSeconds(0.1f);
        GameObject hitEffectInstance = Instantiate(hitEffect, secondHit.point, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(hitEffectInstance);
    }
}