using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class merchant : MonoBehaviour
{
    bool standin;
    internal static bool Merchantsaved = false;
    [SerializeField] Canvas Dialog;
    [SerializeField] TMP_Text text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            standin = true;
            Dialog.enabled = true;
            text.text = "Thanks for saving me. Press E to trasport to my shop with me";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            standin = false;
            Dialog.enabled = false;
        }
    }

    private void Update()
    {
        if (standin && Input.GetKeyDown(KeyCode.E))
        {
            Merchantsaved = true;
            SceneManager.LoadScene("Shop1");
        }
    }
    private void Start()
    {
        Dialog.enabled = false;
    }
}
