using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTestData : MonoBehaviour
{
    Coremon[] savedTeam = new Coremon[3]; 
    void Start()
    {
        GameData.saveData = new UserInfo();
        GameData.saveData.team = new Coremon[3];

        for (int i = 0; i < 3; i++)
        {
            GameData.saveData.team[i] = new Coremon();
        }

        GameData.saveData.team[0].name = "Fushigidatesto";
        GameData.saveData.team[1].name = "Testardon";
        GameData.saveData.team[2].name = "El que queda";

        Debug.Log("Algo mas cambia GameData");
    }

    private void Update()
    {
        savedTeam = GameData.saveData.team;
    }

}
