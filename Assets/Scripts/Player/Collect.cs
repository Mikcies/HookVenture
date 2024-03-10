using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
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
    }
}
