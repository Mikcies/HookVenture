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
    public static string currentSceneName = "TestRoom";
    public static GameObject bonfireObject;
    public static int BonfireCoin;
    public static Vector3 playerPosition;


    [SerializeField]
    TMP_Text bonfireCoinText;


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
        UpdateBonfireCoinText();
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

    void UpdateBonfireCoinText()
    {
        bonfireCoinText.text = "Bonfire Coin: " + BonfireCoin.ToString();
    }
}
