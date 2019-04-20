using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPointerMaster : MonoBehaviour
{
    GameObject pointer1;
    GameObject pointer2;

    GameObject currPointer;

    private void Start()
    {
        pointer1 = transform.GetChild(0).gameObject;
        pointer2 = transform.GetChild(1).gameObject;

        currPointer = pointer1;
        currPointer.SetActive(true);
    }

    public void selectOption(int index)
    {
        currPointer.SetActive(false);
        switch (index)
        {       
            case 1:
                currPointer = pointer1;   
                break;
            case 2:
                currPointer = pointer2;
                break;
        }
        currPointer.SetActive(true);
    }
}
