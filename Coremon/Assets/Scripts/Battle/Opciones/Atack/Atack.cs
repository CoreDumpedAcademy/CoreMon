using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public static bool atacando;
    public bool selecAtac;
    public GameObject pointerAtackUI;
    public GameObject masterPointerUI;

    private void Start()
    {
        pointerAtackUI.SetActive(false);
        atacando = false;
        selecAtac = false;
        masterPointerUI.SetActive(true);
    }

    private void Update()
    {
        if (atacando && !selecAtac){
            pointerAtackUI.SetActive(true);
            masterPointerUI.SetActive(false);
            selecAtac = true;
        }
        if(!atacando && selecAtac)
        {
            selecAtac = false;
            pointerAtackUI.SetActive(false);
            masterPointerUI.SetActive(true);
            Debug.Log("marmota");
        }
    }

    public static void atack(AtackMenu.menuOptions action)
    {
        if (action == AtackMenu.menuOptions.At1)
        {
            //ataque 1
        }
        else if (action == AtackMenu.menuOptions.At2)
        {
            //ataque 2
        }
        else if (action == AtackMenu.menuOptions.At3)
        {
            //ataque 3
        }
        else if (action == AtackMenu.menuOptions.At4)
        {
            //ataque 4
        }
        atacando = false;
        Debug.Log("marmota2");
    }
}
