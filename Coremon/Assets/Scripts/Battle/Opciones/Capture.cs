using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public static int n;

    public void Start()
    {
        n = 1;
    }

    public static bool capturar()
    {
        float cont = 0;
        while(cont < 5)
        {
            //mostar imagen con el estado de captura
            cont += Time.deltaTime;
        }
        if (n > Random.Range(0, 9))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
