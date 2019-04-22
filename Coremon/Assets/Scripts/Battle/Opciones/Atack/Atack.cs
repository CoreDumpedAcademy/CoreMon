using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public static bool atacando;
    public bool selecAtac;
    public GameObject pointerAtackUI;
    public GameObject masterPointerUI;

    BattleController controllerScript;
    CoremonController controllerCoremon;

    public Coremon cor;
    public Coremon enemyCor;

    private void Start()
    {
        pointerAtackUI.SetActive(false);
        atacando = false;
        selecAtac = false;
        masterPointerUI.SetActive(true);
        controllerCoremon = gameObject.GetComponent<CoremonController>();

        //Get  coremons
        cor = GameData.saveData.team[0];
        enemyCor =  controllerCoremon.getWildCoremon();   
        

    }

    private void Update()
    {
        if (atacando && !selecAtac){
            pointerAtackUI.SetActive(true);
            masterPointerUI.SetActive(false);
            selecAtac = true;
        }
        if(!atacando && selecAtac)
        {
            selecAtac = false;
            pointerAtackUI.SetActive(false);
            masterPointerUI.SetActive(true);
            BattleController.active = true;
            Debug.Log("marmota");
        }
    }

    public static void atack(AtackMenu.menuOptions action, Coremon cor, Coremon cor2)
    {
        int typeMult = 1;
        int typeDiv = 1;//variables creadas para evitar errores al convertir int a float
        if (!String.Equals(cor2.Atacks[0].Type, atacando))
        {
            switch (cor2.Atacks[0].Type)
            {
                case "Planta":
                    if (cor.Type == "Fuego")
                    {
                        typeDiv = 2;
                    }
                    else typeMult = 2;
                    break;
                case "Fuego":
                    if (cor.Type == "Agua")
                    {
                        typeDiv = 2;
                    }
                    else typeMult = 2;
                    break;
                default:
                    if (cor.Type == "Fuego")
                    {
                        typeDiv = 2;
                    }
                    else typeMult = 2;
                    break;
            }
        }
        if (action == AtackMenu.menuOptions.At1)
        {
            cor.Ps -= cor2.Atacks[0].Power * cor2.Dam * typeMult / cor.Def / typeDiv;
        }
        else if (action == AtackMenu.menuOptions.At2)
        {
            cor.Ps -= cor2.Atacks[1].Power * cor2.Dam * typeMult / cor.Def / typeDiv;
        }
        else if (action == AtackMenu.menuOptions.At3)
        {
            cor.Ps -= cor2.Atacks[2].Power * cor2.Dam * typeMult / cor.Def / typeDiv;
        }
        else if (action == AtackMenu.menuOptions.At4)
        {
            cor.Ps -= cor2.Atacks[3].Power * cor2.Dam * typeMult / cor.Def / typeDiv;
        }
        atacando = false;
        Debug.Log("marmota2");
    }
}
