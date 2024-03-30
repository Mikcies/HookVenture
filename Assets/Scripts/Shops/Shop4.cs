using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop4 : MonoBehaviour
{
    protected int spawnCount = 0;
    protected bool StandingIn = false;
    [SerializeField]
    protected GameObject ItemPrefab;
    [SerializeField]
    protected Transform ItemLocation;


    [SerializeField]
    protected int ItemValue;

    PlayerMovement move = new PlayerMovement();
    public Collect collect;
    protected void Update()
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
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StandingIn = false;
        }
    }


    protected virtual void CanShop()
    {
        if (StandingIn && collect.CoinAmount >= ItemValue)
        {
            collect.CoinAmount -= ItemValue;
            if (spawnCount < 1)
            {
                Instantiate(ItemPrefab, ItemLocation.position, Quaternion.identity);
                spawnCount++;
            }
        }
    }
}
