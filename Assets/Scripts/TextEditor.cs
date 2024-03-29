using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEditor : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public GameObject player;
    public Collect collect;

    void Start()
    {
        if (collect == null)
        {
            Debug.LogError("Collect script reference is not set in TextEditor.");
            return;
        }
    }

    void Update()
    {
        if (collect != null)
        {
            text.text = collect.CoinAmount.ToString() + "x";
        }
    }
}
