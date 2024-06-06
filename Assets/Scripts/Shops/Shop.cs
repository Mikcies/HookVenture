using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    protected int spawnCount = 0;
    protected bool StandingIn = false;
    [SerializeField]
    protected GameObject ItemPrefab;
    [SerializeField]
    protected Transform ItemLocation;
    [SerializeField] Canvas ItemCanvas;
    [SerializeField] TMP_Text text;


    void Start()
    {
        ItemCanvas.enabled = false;
    }

    [SerializeField]
    protected int ItemValue;

    PlayerMovement move = new PlayerMovement();
    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CanShop();
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StandingIn = true;
            ItemCanvas.enabled = true;
            text.text = $"Press E to buy {ItemPrefab.name} for {ItemValue} coins";
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ItemCanvas.enabled = false;
            StandingIn = false;
        }
    }


    protected virtual void CanShop()
    {
        if (StandingIn && !PlayerMovement.SecondJump && Collect.CoinAmount >= ItemValue)
        {
            
            bonfire.BonfireCoin -= ItemValue;
            if (spawnCount < 1)
            {
                Instantiate(ItemPrefab, ItemLocation.position, Quaternion.identity);
                spawnCount++;
            }
        }
    }
}
