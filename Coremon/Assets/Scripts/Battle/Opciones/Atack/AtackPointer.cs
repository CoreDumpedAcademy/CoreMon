using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPointer : MonoBehaviour
{
    GameObject At1;
    GameObject At2;
    GameObject At3;
    GameObject At4;

    GameObject currPointer;
    void Start()
    {
        At1 = transform.GetChild(0).gameObject;
        At2 = transform.GetChild(1).gameObject;
        At3 = transform.GetChild(2).gameObject;
        At4 = transform.GetChild(3).gameObject;

        currPointer = At1;
        currPointer.SetActive(true);
    }

    public void selectOption(AtackMenu.menuOptions option)
    {
        currPointer.SetActive(false);
        switch (option)
        {
            case AtackMenu.menuOptions.At1:
                currPointer = At1;
                break;
            case AtackMenu.menuOptions.At3:
                currPointer = At3;
                break;
            case AtackMenu.menuOptions.At4:
                currPointer = At4;
                break;
            case AtackMenu.menuOptions.At2:
                currPointer = At2;
                break;
        }
        currPointer.SetActive(true);
    }
}
