using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLateral : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject MenuLateralUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Close()
    {
        MenuLateralUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void Open()
    {
        MenuLateralUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Coredex()
    {
        //activar UI equipo y desactivar UI actual
    }

    public void Team()
    {
        //activar UI equipo y desactivar UI actual
    }

    public void Bag()
    {
        //activar UI mochila y desactivar UI actual
    }

    public void Quit()
    {
        //Cargar escena inicio
    }
}
