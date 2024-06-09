using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerHP : MonoBehaviour
{

    [SerializeField] HPControll controll;

    // Start is called before the first frame update
    void Start()
    {
        HPControll.CurrHP = controll.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
