using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMenu : MonoBehaviour
{
    GameObject frame;

    void Start()
    {
        frame = transform.GetChild(0).gameObject;
    }


    public void activateTeamMenu()
    {
        frame.SetActive(true);
    }

    public void deactivateTeamMenu()
    {
        frame.SetActive(false);
    }
}
