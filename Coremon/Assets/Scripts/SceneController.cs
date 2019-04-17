
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //Class with static functions to load different scenes
    public static void startGame()
    {
        //Retrieve save data from Api
        GameData.playerPos = Vector3Int.zero;
        loadOverworld();
    }

    public static void loadOverworld()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OverworldScene");
    }

    public static void loadBattle()
    {
        GameData.playerPos = Vector3Int.RoundToInt(GameData.player.transform.position);
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}



