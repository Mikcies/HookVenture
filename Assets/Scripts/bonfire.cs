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
    internal static string currentSceneName;
    static GameObject bonfireObject;
    internal static int BonfireCoin;
    internal static Vector3 playerPosition;
    [SerializeField] Canvas bonfireCanvas;
    [SerializeField] TMP_Text text;
    [SerializeField] HPControll controll;
    private void Start()
    {
        bonfireCanvas.enabled = false;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bonfireCanvas.enabled = true;
            text.text = $"Press E to store your coins and set spawn point";
            standin = true;
            playerPosition = other.transform.position;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bonfireCanvas.enabled = false;
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
            HPControll.CurrHP = controll.MaxHP;
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

   
}
