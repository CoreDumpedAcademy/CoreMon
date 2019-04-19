using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Helper class with functions for navigating menus


public class PauseMenuController : MonoBehaviour
{
    PausePointerMaster pointer;
    PauseController.pauseMenuOptions currOption;
    menuInput keyInput = menuInput.None;

    public float waitTime = 1f;

    void Awake()
    {
        //Get the pointer master script from the PointerMaster child object
        pointer = transform.Find("PausePointerMaster").gameObject.GetComponent<PausePointerMaster>();
        currOption = PauseController.pauseMenuOptions.Equipo;
    }

    private void OnDisable()
    {
        updateOption(PauseController.pauseMenuOptions.Equipo);
    }

    public menuInput getInput()
    {
        menuInput input = menuInput.None;
        //Get the input and store it in menuInput
        if (Input.GetAxis("Horizontal") < 0)
        {
            input = menuInput.Left;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            input = menuInput.Right;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            input = menuInput.Down;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            input = menuInput.Up;
        }
        else if (Input.GetButton("Submit"))
        {
            input = menuInput.Yes;
        }

        return input;
    }

    public PauseController.pauseMenuOptions getActions()
    {
        keyInput = getInput();

        Debug.Log(keyInput);

        //If input was detected Check where to move or return option selected

        if (keyInput != menuInput.None)
        { 
            switch (currOption)
            {
                case PauseController.pauseMenuOptions.Equipo:
                    if (keyInput == menuInput.Down) updateOption(PauseController.pauseMenuOptions.Bolsa);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return currOption;
                    }

                    break;
                case PauseController.pauseMenuOptions.Bolsa:
                    if (keyInput == menuInput.Up) updateOption(PauseController.pauseMenuOptions.Equipo);
                    if (keyInput == menuInput.Down) updateOption(PauseController.pauseMenuOptions.Guardar);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return currOption;
                    }

                    break;
                case PauseController.pauseMenuOptions.Guardar:
                    if (keyInput == menuInput.Up) updateOption(PauseController.pauseMenuOptions.Bolsa);
                    if (keyInput == menuInput.Down) updateOption(PauseController.pauseMenuOptions.Salir);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return currOption;
                    }

                    break;
                case PauseController.pauseMenuOptions.Salir:
                    if (keyInput == menuInput.Up) updateOption(PauseController.pauseMenuOptions.Guardar);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return currOption;
                    }
                    break;
                default:
                    updateOption(PauseController.pauseMenuOptions.Equipo);
                    break;
            }
            keyInput = menuInput.None;
            return PauseController.pauseMenuOptions.None;
        }
        else
        {
            return PauseController.pauseMenuOptions.None;
        }

    }

    void updateOption(PauseController.pauseMenuOptions option)
    {
        pointer.selectOption(option);
        currOption = option;
    }

    public enum menuInput { None, Right, Left, Up, Down, Yes, No }
}
