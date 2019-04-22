using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public int move = 425;
    public static int n;
    private Vector3 marmota;
    private float cont;
    private static int capture;
    public GameObject capturadoUI;
    public GameObject escapaUI;
    public GameObject ball;
    public GameObject stars;

    private void Start()
    {
        marmota = ball.transform.position;
        cont = 0;
        capture = 0;
        n = 1;
        capturadoUI.SetActive(false);
        escapaUI.SetActive(false);
        stars.SetActive(false);
    }

    void Update()
    {
        if (cont <= 1 && capture != 0)
        {
            ball.transform.Translate( Vector3.down*Time.deltaTime * move);
            cont += Time.deltaTime;
        }
        if(cont <= 3 && cont > 1 && capture == 1)
        {
            stars.SetActive(true);
            capturadoUI.SetActive(true);
            cont += Time.deltaTime;
        }
        if(cont <= 3 && cont > 1 && capture == 2)
        {
            escapaUI.SetActive(true);
            cont += Time.deltaTime;
        }
        if(cont > 3 && capture == 1)
        {
            BattleController.active = true;
            capture = 0;
            cont = 0;
            SceneController.loadOverworld();
        }
        if (cont > 3 && capture == 2)
        {
            BattleController.active = true;
            capture = 0;
            cont = 0;
            escapaUI.SetActive(false);
            ball.transform.position = marmota;
        }
    }

    public static void capturar()
    {
        if (n > Random.Range(0, 9))
        {
            n = 1;
            capture = 1;
        }
        else
        {
            n++;
            capture = 2;
        }
    }
}
