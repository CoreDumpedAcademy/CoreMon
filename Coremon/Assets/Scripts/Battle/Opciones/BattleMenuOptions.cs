
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
                StartCoroutine("waitToActivate");
                break;

            case BattleController.menuOptions.Cambiar:
                BattleController.active = false;
                teamMenu.SetActive(true);
                break;

            case BattleController.menuOptions.Capturar:
                BattleController.active = false;
                Capture.capturar();                
                Debug.Log(Capture.n);
                break;

            case BattleController.menuOptions.Huir:
                SceneController.loadOverworld();
                break;
        }
    }

    IEnumerator waitToActivate()
    {
        yield return new WaitForSeconds(0.1f);
        Atack.atacando = true;
    }
}

