using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    [SerializeField]
    Transform waterreset;
    [SerializeField]
    GameObject player;

    HPControll controll;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = waterreset.position;
        }
    }
}
