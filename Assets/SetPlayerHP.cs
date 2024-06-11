using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerHP : MonoBehaviour
{

    [SerializeField] HPControll controll;

    void Start()
    {
        HPControll.CurrHP = controll.MaxHP;
        PlayerPrefs.SetInt("SavedHP", 5);
    }

    void Update()
    {
        
    }
}
