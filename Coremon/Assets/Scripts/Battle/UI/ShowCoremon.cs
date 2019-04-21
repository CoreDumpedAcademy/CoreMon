using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoremon : MonoBehaviour
{
    GameObject Batalla;
    Atack atackScript;
    CoremonController controller;

    GameObject cor;
    Vector3 corScale;
    GameObject enemyCor;

    GameObject corUI;
    CoremonUI corUIInfo;
    GameObject enemyCorUI;
    CoremonUI enemtCorUIInfo;

    private void Awake()
    {
        Batalla = GameObject.Find("Batalla");
        atackScript = Batalla.GetComponent<Atack>();
        controller = Batalla.GetComponent<CoremonController>();

        cor = transform.GetChild(0).gameObject;
        enemyCor = transform.GetChild(1).gameObject;
        corUI = transform.GetChild(2).gameObject;
        enemyCorUI = transform.GetChild(3).gameObject;

        corUIInfo = corUI.GetComponent<CoremonUI>();
        enemtCorUIInfo = enemyCorUI.GetComponent<CoremonUI>();

        corScale = cor.GetComponent<RectTransform>().localScale;
        corScale = new Vector3(corScale.x * -1, corScale.y, corScale.z);
        cor.GetComponent<RectTransform>().localScale = corScale;

    }

    private void Update()
    {
        cor.GetComponent<Image>().sprite = atackScript.cor.sprite;
        enemyCor.GetComponent<Image>().sprite = atackScript.enemyCor.sprite;

        corUIInfo.updateText(atackScript.cor);
        enemtCorUIInfo.updateText(atackScript.enemyCor);
    }
}
