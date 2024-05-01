using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour
{
    [SerializeField]
    SceneManagers.directions source;
    [SerializeField]
    SceneManagers.directions destination;
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
            SceneManagers.SetDestinaionDirection(destination);
            UnityEngine.SceneManagement.SceneManager.LoadScene(DestinationScene.ToString());
        }
    }
    void Start()
    {
        if(source == SceneManagers.DestinationDirection) 
        {
            PlayerPref.LoadData();
            player.position = spawnPosition.position;
        }
    }
}
