using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonfireCoins : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;


    void Start()
    {
    }

    void Update()
    {
       UpdateBonfireCoinText();
    }
    void UpdateBonfireCoinText()
    {
        text.text = "Bonfire Coin: " + bonfire.BonfireCoin.ToString();
    }
}
