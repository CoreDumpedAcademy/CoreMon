using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMenu : MonoBehaviour
{
    menuOptions action = menuOptions.None;     //Action the Battle controller will do next
    AtackController menu;                       //Menu controller has all the functions that controll the menu
    Atack atackScript;

    float contador = 0f;
    bool doOnce;
    public GameObject end1;
    public GameObject end2;

    CoremonController controllerCoremon;

    private void Start()
    {
        menu = gameObject.GetComponent<AtackController>();     //Initializing menu controller script
        atackScript = transform.parent.gameObject.GetComponent<Atack>();
        controllerCoremon = GameObject.Find("Batalla").GetComponent<CoremonController>();
        doOnce = false;
        end1.SetActive(false);
        end2.SetActive(false);
        contador = 0f;
    }
    void Update()
    {
        if (action != menuOptions.None)//execute the action by activating and deactivating the UIs
        {
            Atack.atacando = true;
            Atack.atack(action, atackScript.enemyCor, atackScript.cor);
            action = menuOptions.None;

            if (atackScript.enemyCor.Ps <= 0 && !doOnce)
            {
                doOnce = true;
                controllerCoremon.applyExpRewardExp(atackScript.cor, atackScript.enemyCor);
                EndWin();
                Debug.Log(contador + "Este");
                SceneController.loadOverworld();
            }
        }
        if (Atack.atacando)
        {
            action = menu.getActions();                   //Calling the menu controller to open the menu and get an action
        }
        //Do stuff according to the actions received

    }

    //Enum listing the actions the controller will take
    //Referenced by Menu Controller
    public enum menuOptions
    {
        None,
        At1,
        At2,
        At3,
        At4
    }

    public void EndWin()
    {
        end1.SetActive(true);
        while (contador <= 100f)
        {
            contador += Time.deltaTime;
            Debug.Log(contador);
        }
        end1.SetActive(false);
    }
    public void EndLose()
    {
        end2.SetActive(true);
        while (contador <= 3f)
        {
            contador += Time.deltaTime;
        }
        end2.SetActive(false);
    }
}
