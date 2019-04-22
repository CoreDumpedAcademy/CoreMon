using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    GenerateTestData testData;

    private void Start()
    {
        testData = gameObject.GetComponent<GenerateTestData>();
    }
    public void quit()
    {
        Debug.Log("Quitt");
        Application.Quit();
    }

    public void loadGame()
    {
        testData.generateData();
        SceneController.startGame();
    }
}
