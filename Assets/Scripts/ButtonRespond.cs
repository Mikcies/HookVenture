using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRespond : MonoBehaviour
{
    [SerializeField]
    string scenename;
    public void LeaveGame()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(scenename);
    }
}
