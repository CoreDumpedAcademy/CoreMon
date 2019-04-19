using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMaster : MonoBehaviour
{

    GameObject pointerA;
    GameObject pointerCap;
    GameObject pointerH;
    GameObject pointerCmb;

    GameObject currPointer;
    void Start()
    {
        pointerA = transform.GetChild(0).gameObject;
        pointerCap = transform.GetChild(1).gameObject;
        pointerH = transform.GetChild(2).gameObject;
        pointerCmb = transform.GetChild(3).gameObject;

        currPointer = pointerA;
        currPointer.SetActive(true);
    }

    public void selectOption( BattleController.menuOptions option )
    {
        currPointer.SetActive(false);
        switch (option)
        {
            case BattleController.menuOptions.Atacar:
                currPointer = pointerA;
                break;
            case BattleController.menuOptions.Capturar:
                currPointer = pointerCap;
                break;
            case BattleController.menuOptions.Huir:
                currPointer = pointerH;
                break;
            case BattleController.menuOptions.Cambiar:
                currPointer = pointerCmb;
                break;
        }
        currPointer.SetActive(true);
    }


}
