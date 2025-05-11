using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public float timer = 0f;
    public float saveInterval = 30f;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        timer += Time.deltaTime;

        if (timer >= saveInterval)
        {
            SavePosition();
            timer = 0f;
        }
    }

    void SavePosition()
    {
        Vector3 position = player.transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", position.x);
        PlayerPrefs.SetFloat("PlayerPosY", position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", position.z);
        PlayerPrefs.Save();
    }

    public Vector3 RecoverPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerPosX", 0f);
        float y = PlayerPrefs.GetFloat("PlayerPosY", 0f);
        float z = PlayerPrefs.GetFloat("PlayerPosZ", 0f);
        if (x == 0f && y == 0f && z == 0f)
        {
            return player.transform.position;
        }
        return new Vector3(x, y, z);
    }
}
