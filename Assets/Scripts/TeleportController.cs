using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour
{
    [SerializeField]
    SceneManager.directions source;
    [SerializeField]
    SceneManager.directions destination;
    [SerializeField]
    string DestinationScene;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform spawnPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPref.SaveData();
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.SetDestinaionDirection(destination);
            UnityEngine.SceneManagement.SceneManager.LoadScene(DestinationScene.ToString());
        }
    }
    void Start()
    {
        if(source == SceneManager.DestinationDirection) 
        {
            PlayerPref.LoadData();
            player.position = spawnPosition.position;
        }
    }
}
