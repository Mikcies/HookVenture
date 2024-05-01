using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonfireCoins : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public GameObject player;
    public BonfireCoins bonfires;

    void Start()
    {
        if (bonfires == null)
        {
            Debug.LogError("Collect script reference is not set in TextEditor.");
            return;
        }
    }

    void Update()
    {
        if (bonfires != null)
        {
        }
    }
}
