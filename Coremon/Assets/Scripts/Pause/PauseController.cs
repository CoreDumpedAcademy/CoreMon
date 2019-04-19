﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    pauseMenuOptions action = pauseMenuOptions.None;
    PauseMenuController menu;

    TeamMenu teamMenu;
    BagMenu bagMenu;

    bool active = true; //Tells is the main menu is active or showing a sub window

    void Start()
    {
        menu = GetComponent<PauseMenuController>();
        teamMenu = transform.Find("TeamMenu").GetComponent<TeamMenu>();
        bagMenu = transform.Find("BagMenu").GetComponent<BagMenu>();
    }


    void Update()
    {
        if (active)    //If no sub-window is open
        {
            Debug.Log("take action");
            action = menu.getActions();
            if (action != pauseMenuOptions.None)
            {
                active = false;

                takeAction(action);
            }
        }
        else
        {
            //If opened menu for equipo or bolsa submit button will exit
            if ( (action == pauseMenuOptions.Bolsa || action == pauseMenuOptions.Equipo))
            {
                if (Input.GetButtonDown("Submit"))
                {
                    deactivateSubWindow(action);
                    active = true;
                }
            }
        }
    }

    void takeAction(pauseMenuOptions option)
    {
        switch (option)
        {
            case pauseMenuOptions.Equipo:
            case pauseMenuOptions.Bolsa:
                activateSubWindow(action);
                break;
            case pauseMenuOptions.Guardar:
                //Save game. Activate menu again when saving is finished.
                Debug.Log("saving...");
                active = true;
                break;
            case pauseMenuOptions.Salir:
                //go back to Inicio
                Debug.Log("exiting...");
                active = true;
                break;
        }
    }

    private void activateSubWindow(pauseMenuOptions option)
    {
        switch (action)
        {
            case pauseMenuOptions.Equipo:
                teamMenu.activateTeamMenu();
                break;
            case pauseMenuOptions.Bolsa:
                bagMenu.activateBagMenu();
                break;
        }
    }

    private void deactivateSubWindow(pauseMenuOptions option)
    {
        switch (action)
        {
            case pauseMenuOptions.Equipo:
                teamMenu.deactivateTeamMenu();
                break;
            case pauseMenuOptions.Bolsa:
                bagMenu.deactivateBagMenu();
                break;
            case pauseMenuOptions.Guardar:
                //Actiaves "Saving" massage
                break;         
        }
    }

    public enum pauseMenuOptions
    {
        None,
        Equipo,
        Bolsa,
        Guardar,
        Salir
    }
}
