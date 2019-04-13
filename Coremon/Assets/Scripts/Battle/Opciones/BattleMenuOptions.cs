using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenuOptions : MonoBehaviour
{
    public static void opciones(BattleController.menuOptions action)
    {
        if (action == BattleController.menuOptions.Atacar)
        {
           Atack.atack();
        }
        else if (action == BattleController.menuOptions.Cambiar)
        {
            //script cambio pokemon
        }
        else if (action == BattleController.menuOptions.Capturar)
        {
            if (Capture.capturar())
            {
                Capture.n = 1;
                //SceneManager.LoadScene("Game");
            }
            else
            {
                Capture.n++;
            }
            Debug.Log(Capture.n);
        }
        else if (action == BattleController.menuOptions.Huir)
        {
            //SceneManager.LoadScene("Game");
        }
    }
}
