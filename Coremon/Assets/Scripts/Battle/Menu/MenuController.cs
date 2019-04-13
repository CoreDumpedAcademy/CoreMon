using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Helper class with functions for navigating menus


public class MenuController : MonoBehaviour
{
    PointerMaster pointer;
    BattleController.menuOptions currOption = BattleController.menuOptions.Atacar;
    menuInput keyInput = menuInput.None;

    void Start()
    {
        //Get the pointer master script from the PointerMaster child object
        pointer = transform.Find("PointerMaster").gameObject.GetComponent<PointerMaster>();
    }

    public BattleController.menuOptions getActions(){

        //Get the input and store it in menuInput

        if (Input.GetAxis("Horizontal") < 0)        
        {
            keyInput = menuInput.Left;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            keyInput = menuInput.Right;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            keyInput = menuInput.Down;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            keyInput = menuInput.Up;
        }
        else if (Input.GetButtonDown("Submit"))
        {
            keyInput = menuInput.Yes;
        }


        //If input was detected Check where to move or return option selected

        if (keyInput != menuInput.None)
        {

            switch (currOption)
            {
                case BattleController.menuOptions.Atacar:
                    if (keyInput == menuInput.Right) updateOption(BattleController.menuOptions.Cambiar);
                    if (keyInput == menuInput.Down) updateOption(BattleController.menuOptions.Capturar);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return BattleController.menuOptions.Atacar;
                    }

                    break;
                case BattleController.menuOptions.Capturar:
                    if (keyInput == menuInput.Right) updateOption(BattleController.menuOptions.Huir);
                    if (keyInput == menuInput.Up) updateOption(BattleController.menuOptions.Atacar);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return BattleController.menuOptions.Capturar;
                    }

                    break;
                case BattleController.menuOptions.Huir:
                    if (keyInput == menuInput.Left) updateOption(BattleController.menuOptions.Capturar);
                    if (keyInput == menuInput.Up) updateOption(BattleController.menuOptions.Cambiar);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return BattleController.menuOptions.Huir; 
                    }

                    break;
                case BattleController.menuOptions.Cambiar:
                    if (keyInput == menuInput.Left) updateOption(BattleController.menuOptions.Atacar);
                    if (keyInput == menuInput.Down) updateOption(BattleController.menuOptions.Huir);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return BattleController.menuOptions.Cambiar;
                    }
                    break;
            }
            keyInput = menuInput.None;
            return BattleController.menuOptions.None;
        }
        else
        {
            return BattleController.menuOptions.None;
        }
        
    }
    void updateOption(BattleController.menuOptions option)
    {
        pointer.selectOption(option);
        currOption = option;
    }
    enum menuInput { None, Right, Left, Up, Down, Yes, No }
}
