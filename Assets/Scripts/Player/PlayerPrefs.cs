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
        PlayerPrefs.SetInt("CoinInBonfire", bonfire.BonfireCoin);
        PlayerPrefs.SetInt("SewerTreasure", Collect.SewerTreasure);
        PlayerPrefs.SetInt("CellsTreasure", Collect.CellsTreasure);
        PlayerPrefs.SetInt("CannalBossAlive", CannalBoss.CannalBossAlive ? 1 : 0);
        PlayerPrefs.SetInt("CaveBossAlive", CaveBoss.CaveBossAlive ? 1 : 0);
        PlayerPrefs.SetInt("MerchantSaved", merchant.Merchantsaved ? 1 : 0);

        PlayerPrefs.Save();
    }
    internal static void LoadData()
    {
        HPControll.CurrHP = PlayerPrefs.GetInt("SavedHP");
        Collect.CoinAmount = PlayerPrefs.GetInt("SavedCoins");
        PlayerMovement.Dash = (PlayerPrefs.GetInt("Dash") != 0);
        PlayerMovement.SecondJump = (PlayerPrefs.GetInt("SecondJump") != 0);
        ShootGrapple.Claw = (PlayerPrefs.GetInt("Claw") != 0);
        bonfire.BonfireCoin = (PlayerPrefs.GetInt("CoinInBonfire"));
        Collect.SewerTreasure = PlayerPrefs.GetInt("SewerTreasure");
        Collect.CellsTreasure = PlayerPrefs.GetInt("CellsTreasure");
        CannalBoss.CannalBossAlive = (PlayerPrefs.GetInt("CannalBossAlive") != 0);
        CaveBoss.CaveBossAlive = (PlayerPrefs.GetInt("CaaveBossAlive") != 0);
        merchant.Merchantsaved = (PlayerPrefs.GetInt("MerchantSaved") != 0);
    }
}
