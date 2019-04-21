
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMenuOptions : MonoBehaviour
{
    BattleController controllerScript;
    GameObject teamMenu;

    private void Start()
    {
        controllerScript = gameObject.GetComponent<BattleController>();
        teamMenu = GameObject.Find("TeamCanvas").transform.Find("TeamMenu").gameObject;
    }
    public void actOn(BattleController.menuOptions action)
    {
        switch (action)
        {
            case BattleController.menuOptions.Atacar:
                controllerScript.active = false;
                Atack.atacando = true;
                break;
            case BattleController.menuOptions.Cambiar:
                controllerScript.active = false;
                Debug.Log(controllerScript.active);
                teamMenu.SetActive(true);
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

