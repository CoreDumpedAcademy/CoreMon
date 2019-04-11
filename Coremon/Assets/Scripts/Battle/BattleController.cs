using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    PointerMaster pointer;
    menuOptions currOption = menuOptions.Atacar;
    menuInput keyInput = menuInput.None;
    void Start()
    {
        //Get the pointer master script from the PointerMaster child object
        pointer = transform.Find("PointerMaster").gameObject.GetComponent<PointerMaster>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            keyInput = menuInput.Left;
        } else if (Input.GetAxis("Horizontal") > 0)
        {
            keyInput = menuInput.Right;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            keyInput = menuInput.Down;
        } else if (Input.GetAxis("Vertical") > 0)
        {
            keyInput = menuInput.Up;
        }

        Debug.Log(keyInput);

        if(keyInput != menuInput.None)
        {

            switch (currOption)
            {
                case menuOptions.Atacar:
                    if (keyInput == menuInput.Right) updateOption(menuOptions.Cambiar);
                    if (keyInput == menuInput.Down) updateOption(menuOptions.Capturar);

                    if(keyInput == menuInput.Yes)
                    {
                        //Add function call
                    }

                    break;
                case menuOptions.Capturar:
                    if (keyInput == menuInput.Right) updateOption(menuOptions.Huir);
                    if (keyInput == menuInput.Up) updateOption(menuOptions.Atacar);

                    if (keyInput == menuInput.Yes)
                    {
                        //Add function call
                    }

                    break;
                case menuOptions.Huir:
                    if (keyInput == menuInput.Left) updateOption(menuOptions.Capturar);
                    if (keyInput == menuInput.Up) updateOption(menuOptions.Cambiar);

                    if (keyInput == menuInput.Yes)
                    {
                        //Add function call
                    }

                    break;
                case menuOptions.Cambiar:
                    if (keyInput == menuInput.Left) updateOption(menuOptions.Atacar);
                    if (keyInput == menuInput.Down) updateOption(menuOptions.Huir);

                    if (keyInput == menuInput.Yes)
                    {
                        //Add function call
                    }

                    break;
            }

            keyInput = menuInput.None;
        }
        



    }

    void updateOption(menuOptions option)
    {
        pointer.selectOption(option);
        currOption = option;
    }

    public enum menuOptions
    {
        Atacar,
        Capturar,
        Huir,
        Cambiar
    }
    
    enum menuInput {None, Right, Left, Up, Down, Yes, No}
}
