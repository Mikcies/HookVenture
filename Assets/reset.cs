using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.Dash = false;
            PlayerMovement.SecondJump = false;
            ShootGrapple.Claw = false;
        }
    }
}
