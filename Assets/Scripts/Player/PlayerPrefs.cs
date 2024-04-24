using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    internal static void SaveData()
    {
        PlayerPrefs.SetInt("SavedHP", HPControll.CurrHP);
        PlayerPrefs.SetInt("SavedCoins", Collect.CoinAmount);
        PlayerPrefs.SetInt("Dash", (PlayerMovement.Dash ? 1 : 0));
        PlayerPrefs.SetInt("SecondJump", (PlayerMovement.SecondJump ? 1 : 0));
        PlayerPrefs.SetInt("Claw", (ShootGrapple.Claw ? 1 : 0));
        PlayerPrefs.Save();
    }
    internal static void LoadData()
    {
        HPControll.CurrHP = PlayerPrefs.GetInt("SavedHP");
        Collect.CoinAmount = PlayerPrefs.GetInt("SavedCoins");
        PlayerMovement.Dash = (PlayerPrefs.GetInt("Dash") != 0);
        PlayerMovement.SecondJump = (PlayerPrefs.GetInt("SecondJump") != 0);
        ShootGrapple.Claw = (PlayerPrefs.GetInt("Claw") != 0);
    }
}
