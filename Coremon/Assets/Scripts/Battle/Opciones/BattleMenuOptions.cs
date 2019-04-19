
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenuOptions : MonoBehaviour
{
    public static void opciones(BattleController.menuOptions action)
    {
        switch (action)
        {
            case BattleController.menuOptions.Atacar:
                Atack.atacando = true;
                break;
            case BattleController.menuOptions.Cambiar:
                break;
            case BattleController.menuOptions.Capturar:
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

                break;
            case BattleController.menuOptions.Huir:
                SceneController.loadOverworld();
                break;
        }
    }
}

