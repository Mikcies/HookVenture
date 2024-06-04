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
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPref.SaveData();

            if (DestinationScene == "CannalBossScene" && CannalBoss.CannalBossAlive == false)
            {
                SceneManagers.SetDestinaionDirection(destination);
                SceneManager.LoadScene("CannalBossDeadScene");
            }
            else if (DestinationScene == "CaveBoss" && !CaveBoss.CaveBossAlive)
            {
                SceneManagers.SetDestinaionDirection(destination);
                SceneManager.LoadScene("CaveBossDeadScene");
            }
            else
            {
                SceneManagers.SetDestinaionDirection(destination);
                SceneManager.LoadScene(DestinationScene);
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

        Debug.Log("Cave boss " + CaveBoss.CaveBossAlive);
        Debug.Log("Cannal Boss " + CannalBoss.CannalBossAlive);
    }
}
