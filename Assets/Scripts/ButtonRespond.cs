using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRespond : MonoBehaviour
{
    [SerializeField]
    string scenename;

    string sceneFromPlayerPrefs;
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
        string sceneFromPrefs = PlayerPrefs.GetString("BonfireScene");
        if(sceneFromPlayerPrefs == "")
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene(sceneFromPlayerPrefs);
            PlayerPref.LoadData();
        }
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
    }
    private void Update()
    {
        Debug.Log(sceneFromPlayerPrefs);

    }
}
