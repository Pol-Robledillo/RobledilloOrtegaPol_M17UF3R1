using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private SphereCollider sphereCollider;
    public int weaponID;

    public float rotationSpeed = 90f;
    public float floatAmplitude = 0.5f;
    public float floatFrequency = 1f;
    public float minLightIntensity = 0.5f;
    public float maxLightIntensity = 1.5f;
    public float intensityFrequency = 1f;
    private Vector3 startPosition;
    private Light pickupLight;

    void Start()
    {
        pickupLight = GetComponent<Light>();
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);

        float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPosition + new Vector3(0f, yOffset, 0f);

        float intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity,(Mathf.Sin(Time.time * intensityFrequency) + 1f) / 2f);pickupLight.intensity = intensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NewPlayerController player = other.GetComponent<NewPlayerController>();
            if (player != null)
            {
                switch (weaponID)
                {
                    case 1:
                        player.hasBurstWeapon = true;
                        break;
                    case 2:
                        player.hasAutoWeapon = true;
                        break;
                }
            }
        }
    }
}
