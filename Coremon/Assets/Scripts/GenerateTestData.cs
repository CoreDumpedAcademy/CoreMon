using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTestData : MonoBehaviour
{
    CoremonController controller;
    Coremon[] savedTeam = new Coremon[3];
    UserInfo savedData;
    void Start()
    {
        controller = gameObject.GetComponent<CoremonController>();

        GameData.saveData = new UserInfo();
        GameData.saveData.team = new Coremon[3];
        GameData.saveData.coredex = new int[30];
        GameData.saveData.bag = new Item[5];
        for(int i = 0; i < 30; i++)
        {
            GameData.saveData.coredex[i] = 0;
        }

        GameData.saveData.coredex[0] = 2;
        GameData.saveData.coredex[1] = 2;
        GameData.saveData.coredex[2] = 2;
        GameData.saveData.coredex[5] = 1;
        GameData.saveData.coredex[15] = 1;
        GameData.saveData.coredex[29] = 1;

        for (int i = 0; i < 3; i++)
        {
            GameData.saveData.team[i] = new Coremon();
            GameData.saveData.team[i].sprite = controller.getCoremonSprite(GameData.saveData.team[i]);
        }

        GameData.saveData.team[0].name = "Fushigidatesto";
        GameData.saveData.team[1].name = "Testardon";
        GameData.saveData.team[1].NumCoremon = 2;
        GameData.saveData.team[2].name = "El que queda";
        GameData.saveData.team[2].NumCoremon = 3;


        GameData.saveData.username = "TestData";
        GameData.saveData.money = 100;

        Item item0 = new Item();
        Item item1 = new Item();

        item0.name = "Coreball";
        item0.amount = 20;
        item1.name = "Supercore";
        item1.amount = 10;

        GameData.saveData.bag[0] = item0;
        GameData.saveData.bag[1] = item1;
    }

    private void Update()
    {
        savedTeam = GameData.saveData.team;
        savedData = GameData.saveData;
    }

}
