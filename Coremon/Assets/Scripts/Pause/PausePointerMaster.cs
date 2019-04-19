using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePointerMaster : MonoBehaviour
{

    GameObject pointerEq;
    GameObject pointerBol;
    GameObject pointerG;
    GameObject pointerSal;

    GameObject currPointer;
    void Start()
    {
        pointerEq = transform.GetChild(0).gameObject;
        pointerBol = transform.GetChild(1).gameObject;
        pointerG = transform.GetChild(2).gameObject;
        pointerSal = transform.GetChild(3).gameObject;

        currPointer = pointerEq;
        currPointer.SetActive(true);
    }

    public void selectOption(PauseController.pauseMenuOptions option)
    {
        currPointer.SetActive(false);
        switch (option)
        {
            case PauseController.pauseMenuOptions.Equipo:
                currPointer = pointerEq;
                break;
            case PauseController.pauseMenuOptions.Bolsa:
                currPointer = pointerBol;
                break;
            case PauseController.pauseMenuOptions.Guardar:
                currPointer = pointerG;
                break;
            case PauseController.pauseMenuOptions.Salir:
                currPointer = pointerSal;
                break;
        }
        currPointer.SetActive(true);
    }


}
