using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMenu : MonoBehaviour
{

    GameObject frame;

    void Start()
    {
        frame = transform.GetChild(0).gameObject;
    }

    public void activateBagMenu()
    {
        frame.SetActive(true);
    }

    public void deactivateBagMenu()
    {
        frame.SetActive(false);
    }
}
