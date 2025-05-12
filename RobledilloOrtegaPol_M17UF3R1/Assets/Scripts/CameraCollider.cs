using UnityEngine;

public class CameraRaycastController : MonoBehaviour
{
    public Transform player;
    private float maxRayDistance = 3f;
    public float defaultZPosition;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned in the inspector.");
        }
    }
    void Update()
    {
        Vector3 directionToCamera = (transform.position - player.position).normalized;

        Ray ray = new Ray(player.position, directionToCamera);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayDistance) && !hit.collider.gameObject.CompareTag("Player"))
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.z = -(hit.distance - 0.1f);
            transform.localPosition = newPosition;
        }
        else
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.z = defaultZPosition;
            transform.localPosition = newPosition;
        }
    }
}