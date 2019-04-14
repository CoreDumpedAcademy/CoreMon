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
            Debug.Log("marmota");
            pointerAtackUI.SetActive(true);
            masterPointerUI.SetActive(false);
            selecAtac = true;
        }
    }
}
