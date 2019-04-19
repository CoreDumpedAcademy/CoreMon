using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    pauseMenuOptions action = pauseMenuOptions.None;
    PauseMenuController menu;

    float inputWaitTime = 0.2f;
    float counter = 0f;

    bool active = true; //Tells is the main menu is active or showing a sub window

    void Start()
    {
        menu = GetComponent<PauseMenuController>();
    }


    void Update()
    {
        if (active)
        {
            counter += Time.deltaTime;
            if(counter >= inputWaitTime)
            {
                counter = 0;
                Debug.Log("take action");
                action = menu.getActions();
                //action
            }
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
