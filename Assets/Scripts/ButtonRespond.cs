using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRespond : MonoBehaviour
{
    [SerializeField]
    string scenename;

    string sceneFromPlayerPrefs;

    private void Start()
    {

    }
    public void LeaveGame()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(scenename);
    }
    public void Continue()
    {
        sceneFromPlayerPrefs = PlayerPrefs.GetString("SavedScene");
        if(PlayerPrefs.GetString("SavedScene") == "")
        {
            SceneManager.LoadScene("TestRoom");
            PlayerPrefs.DeleteAll();
        }
        SceneManager.LoadScene(sceneFromPlayerPrefs);
        PlayerPref.LoadData();

    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
    }
}
