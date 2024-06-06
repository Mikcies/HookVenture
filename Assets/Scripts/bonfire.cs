using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bonfire : MonoBehaviour
{
    bool standin;
    internal static string currentSceneName = "TestRoom";
    static GameObject bonfireObject;
    internal static int BonfireCoin;
    internal static Vector3 playerPosition;

    private void Start()
    {
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            standin = true;
            playerPosition = other.transform.position;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            standin = false;
        }
    }

    private void Update()
    {
        SaveSceneName();
    }

    void SaveSceneName()
    {
        if (standin && Input.GetKeyDown(KeyCode.E))
        {
            currentSceneName = SceneManager.GetActiveScene().name;
            BonfireCoin += Collect.CoinAmount;
            Collect.CoinAmount = 0;
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

   
}
