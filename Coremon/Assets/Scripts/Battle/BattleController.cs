using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    menuOptions action = menuOptions.None;
    MenuController menu;
    private void Start()
    {
        menu = gameObject.GetComponent<MenuController>();
    }
    void Update()
    {
        action = menu.getActions();
        Debug.Log(action);
    }



    public enum menuOptions
    {
        None,
        Atacar,
        Capturar,
        Huir,
        Cambiar
    }


}
