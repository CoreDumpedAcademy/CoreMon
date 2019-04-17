using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("Quitt");
        Application.Quit();
    }

    public void loadGame()
    {
        SceneController.startGame();
    }
}
