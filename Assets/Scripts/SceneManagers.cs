using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagers : MonoBehaviour
{
    public static directions DestinationDirection { get; private set; }
    public enum directions
    {
        LEFT,
        RIGHT, 
        UP,
        DOWN
    }
    public static void SetDestinaionDirection(directions direction)
    {
        DestinationDirection = direction;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainMenu");
        }

    }
    private void Awake()
    {
        string currScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene",currScene);
        Debug.Log("CurrHP: " + HPControll.CurrHP);
        Debug.Log("PlayerPrefHP: " + PlayerPrefs.GetInt("SavedHP"));
    }
}
