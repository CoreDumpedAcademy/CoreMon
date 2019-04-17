using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackController : MonoBehaviour
{
    AtackPointer pointer;
    AtackMenu.menuOptions currOption = AtackMenu.menuOptions.At1;
    menuInput keyInput = menuInput.None;

    void Start()
    {
        //Get the pointer master script from the PointerMaster child object
        pointer = transform.Find("AtackPointer").gameObject.GetComponent<AtackPointer>();
    }

    public AtackMenu.menuOptions getActions()
    {

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
                case AtackMenu.menuOptions.At1:
                    if (keyInput == menuInput.Right) updateOption(AtackMenu.menuOptions.At2);
                    if (keyInput == menuInput.Down) updateOption(AtackMenu.menuOptions.At3);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return AtackMenu.menuOptions.At1;
                    }

                    break;
                case AtackMenu.menuOptions.At3:
                    if (keyInput == menuInput.Right) updateOption(AtackMenu.menuOptions.At4);
                    if (keyInput == menuInput.Up) updateOption(AtackMenu.menuOptions.At1);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return AtackMenu.menuOptions.At3;
                    }

                    break;
                case AtackMenu.menuOptions.At4:
                    if (keyInput == menuInput.Left) updateOption(AtackMenu.menuOptions.At3);
                    if (keyInput == menuInput.Up) updateOption(AtackMenu.menuOptions.At2);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return AtackMenu.menuOptions.At4;
                    }

                    break;
                case AtackMenu.menuOptions.At2:
                    if (keyInput == menuInput.Left) updateOption(AtackMenu.menuOptions.At1);
                    if (keyInput == menuInput.Down) updateOption(AtackMenu.menuOptions.At4);

                    if (keyInput == menuInput.Yes)
                    {
                        keyInput = menuInput.No;
                        return AtackMenu.menuOptions.At2;
                    }
                    break;
            }
            keyInput = menuInput.None;
            return AtackMenu.menuOptions.None;
        }
        else
        {
            return AtackMenu.menuOptions.None;
        }

    }
    void updateOption(AtackMenu.menuOptions option)
    {
        pointer.selectOption(option);
        currOption = option;
    }
    enum menuInput { None, Right, Left, Up, Down, Yes, No }
}
