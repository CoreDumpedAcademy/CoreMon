using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    Movement moveScript;      //reference to movement script
    GameObject pauseCanvas;   //reference to pause menu canvas starts inactive

    void OnEnable()
    {
        moveScript = GetComponent<Movement>();
        pauseCanvas = GameObject.Find("Pause").transform.Find("PauseCanvas").gameObject; //Pause canvas child of "Pause" object
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("Cancel"))
        {
            moveScript.enabled = !moveScript.enabled;
            pauseCanvas.SetActive( ! pauseCanvas.activeSelf );
        }
    }
}
