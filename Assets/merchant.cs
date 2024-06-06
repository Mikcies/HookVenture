using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class merchant : MonoBehaviour
{
    bool standin;
    internal static bool Merchantsaved = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            standin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            standin = false;
        }
    }

    private void Update()
    {
        if (standin && Input.GetKeyDown(KeyCode.E))
        {
            Merchantsaved = true;
        }
    }

}
