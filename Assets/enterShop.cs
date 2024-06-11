using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class enterShop : MonoBehaviour
{
    [SerializeField]
    SceneManagers.directions source;
    [SerializeField]
    SceneManagers.directions destination;
    [SerializeField]
    string DestinationScene;
    [SerializeField]
    Canvas shopCanvas;
    [SerializeField] TMP_Text text;


    [SerializeField]
    Transform player;

    [SerializeField]
    Transform spawnPosition;




    bool standin = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.CompareTag("Player"))
        {
            shopCanvas.enabled = true;
            standin = true;
            text.text = "Press E to enter shop";
        }
        else
        {
            shopCanvas.enabled = false;
            standin = false;
        }

    }

    private void Update()
    {
        if (standin && Input.GetKey(KeyCode.E))
        {
            PlayerPref.SaveData();
            if (DestinationScene == "Shop1")
            {
                if (merchant.Merchantsaved)
                {
                    SceneManagers.SetDestinaionDirection(destination);
                    SceneManager.LoadScene("Shop1");
                }
                else
                {
                    SceneManagers.SetDestinaionDirection(destination);
                    SceneManager.LoadScene("ShopWithoutMerchant");
                }
            }
        }
    }
    void Start()
    {
        if (source == SceneManagers.DestinationDirection)
        {
            PlayerPref.LoadData();
            player.position = spawnPosition.position;
        }
    }
}
