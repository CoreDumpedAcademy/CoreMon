using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoremonUI : MonoBehaviour
{
    Text Name;
    Text PsText;
    Text Lvl;

    void Start()
    {
        Name = transform.GetChild(0).gameObject.GetComponent<Text>();
        PsText = transform.GetChild(1).gameObject.GetComponent<Text>();
        Lvl = transform.GetChild(2).gameObject.GetComponent<Text>();
    }

    public void updateText(Coremon cor)
    {
        Name.text = cor.name;
        PsText.text = cor.Ps + "/" + cor.PsMax;
        Lvl.text = cor.Level.ToString();
    }
}
