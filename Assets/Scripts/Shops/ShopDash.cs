using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopDash : MonoBehaviour
{
    private int spawnCount = 0;
    private bool StandingIn;
    [SerializeField]
    protected GameObject ItemPrefab;
    [SerializeField]
    private Transform ItemLocation;
    [SerializeField] Canvas ItemCanvas;
    [SerializeField] TMP_Text text;
    [SerializeField]
    int ItemValue;

    void Start()
    {
        ItemCanvas.enabled = false;
    }



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
        if (StandingIn && !PlayerMovement.Dash && Collect.CoinAmount >= ItemValue)
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
