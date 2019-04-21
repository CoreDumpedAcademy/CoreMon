using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUI : MonoBehaviour
{

    Atack atackScript;

    Text at1Text;
    Text at2Text;
    Text at3Text;
    Text at4Text;

    void Start()
    {
        atackScript = GameObject.Find("Batalla").GetComponent<Atack>();

        at1Text = transform.GetChild(0).GetComponent<Text>();
        at2Text = transform.GetChild(1).GetComponent<Text>();
        at3Text = transform.GetChild(2).GetComponent<Text>(); 
        at4Text = transform.GetChild(3).GetComponent<Text>();
    }


    void Update()
    {
        at1Text.text = atackScript.cor.Atacks[0].name;
        at2Text.text = atackScript.cor.Atacks[1].name;
        at3Text.text = atackScript.cor.Atacks[2].name;
        at4Text.text = atackScript.cor.Atacks[3].name;
    }
}
