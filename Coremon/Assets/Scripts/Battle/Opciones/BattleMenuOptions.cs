
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenuOptions : MonoBehaviour
{
    GameObject teamMenu;

    private void Start()
    {
        teamMenu = GameObject.Find("CoremonCanvas").transform.Find("TeamMenu").gameObject;
    }
    public void actOn(BattleController.menuOptions action)
    {
        switch (action)
        {
            case BattleController.menuOptions.Atacar:
                BattleController.active = false;
                Atack.atacando = true;
                break;
            case BattleController.menuOptions.Cambiar:
                BattleController.active = false;
                Debug.Log(BattleController.active);
                teamMenu.SetActive(true);
                break;
            case BattleController.menuOptions.Capturar:
                if (Capture.capturar())
                {
                    Capture.n = 1;
                    SceneController.loadOverworld();
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

