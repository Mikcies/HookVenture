using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExplorationEdit : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    Collect collect;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = $"Treasures found in the sewers{Collect.SewerTreasure}/5 ";
    }
}
