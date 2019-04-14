using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    menuOptions action = menuOptions.None;     //Action the Battle controller will do next
    MenuController menu;                       //Menu controller has all the functions that controll the menu
    private void Start()
    {
        menu = gameObject.GetComponent<MenuController>();     //Initializing menu controller script
    }
    void Update()
    {
        if (!Atack.atacando)
        {
            action = menu.getActions();                   //Calling the menu controller to open the menu and get an action
        }
        if(action != menuOptions.None)
        {
            BattleMenuOptions.opciones(action);
            action = menuOptions.None;
        }
        //Do stuff according to the actions received

    }

    //Enum listing the actions the controller will take
    //Referenced by Menu Controller
    public enum menuOptions
    {
        None,
        Atacar,
        Capturar,
        Huir,
        Cambiar
    }


}
