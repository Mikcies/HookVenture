using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    [SerializeField]
    internal int CoinAmount = 25;

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloak")
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.SecondJump = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Claw")
        {
            ShootGrapple shootGrapple = GetComponent<ShootGrapple>();
            shootGrapple.Claw = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Dash")
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.Dash = true;
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
    }
    
    

}
