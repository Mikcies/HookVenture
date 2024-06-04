using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    internal static int CoinAmount;
    internal static int SewerTreasure;
    internal static int CellsTreasure;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloak")
        {
            PlayerMovement.SecondJump = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Claw")
        {
            ShootGrapple.Claw = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Dash")
        {
            PlayerMovement.Dash = true;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Coin")
        {
            int Amount = Random.Range(1, 11);
            CoinAmount += Amount;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "HearthPiece")
        {
            HPControll hp = GetComponent<HPControll>();
            hp.Hearthpieces++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "SewersTreasure")
        {
            SewerTreasure += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "CellsTreasure")
        {
            CellsTreasure += 1;
            Destroy(collision.gameObject);
        }
    }
    
    

}
