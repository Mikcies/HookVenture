﻿using System.Collections;
using System.Collections.Generic;
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
    public void Continue()
    {
        string sceneFromPrefs = PlayerPrefs.GetString("BonfireScene");
        string loadedscene = PlayerPrefs.GetString("LastScene");

        if (string.IsNullOrEmpty(sceneFromPrefs))
        {
            NewGame();
        }
        else if (string.IsNullOrEmpty(loadedscene))
        {
            SceneManager.LoadScene(loadedscene);
            PlayerPref.LoadData();
        }


    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("SavedCoins", 0);
        SceneManager.LoadScene("Tutorial");
    }
}
