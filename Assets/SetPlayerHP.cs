using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerHP : MonoBehaviour
{

    [SerializeField] HPControll controll;

    private void Awake()
    {
        HPControll.CurrHP = controll.MaxHP;
        PlayerPrefs.SetInt("SavedHP", HPControll.CurrHP);
    }
    void Start()
    {
       
    }

    void Update()
    {
        
    }
}
