using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneManager : MonoBehaviour
{
    [field: SerializeField] Boss CurrentBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CurrentBoss.IsAlive())
        {
            DisableEntranceColliders();
        }
    }
    void DisableEntranceColliders()
    {
        GameObject[] entranceObjects = GameObject.FindGameObjectsWithTag("Entrance");

        foreach (GameObject entranceObject in entranceObjects)
        {
            entranceObject.SetActive(false);
        }
    }
}

