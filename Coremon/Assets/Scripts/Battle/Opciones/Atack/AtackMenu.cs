using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMenu : MonoBehaviour
{
    menuOptions action = menuOptions.None;     //Action the Battle controller will do next
    AtackController menu;                       //Menu controller has all the functions that controll the menu
    public Coremon cor;
    public Coremon enemyCor;
    private void Start()
    {
        menu = gameObject.GetComponent<AtackController>();     //Initializing menu controller script
    }
    void Update()
    {
        if (action != menuOptions.None)//execute the action by activating and deactivating the UIs
        {
            Atack.atacando = true;
            Atack.atack(action, cor, enemyCor);
            action = menuOptions.None;
        }
        if (Atack.atacando)
        {
            action = menu.getActions();                   //Calling the menu controller to open the menu and get an action
        }
        //Do stuff according to the actions received

    }

    //Enum listing the actions the controller will take
    //Referenced by Menu Controller
    public enum menuOptions
    {
        None,
        At1,
        At2,
        At3,
        At4
    }
}
