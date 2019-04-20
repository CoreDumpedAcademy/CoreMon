using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    int[] optionsAvailable = new int[2];   //Maps which Coremon will be shown in each option slots using their index in SaveData
    int currOption = 1;
    menuInput input;
    BattleController battleController;
    GameObject menu;
    Atack atackScript;    //Reference to Atack script, which contains the coremon currently in battle

    TeamPointerMaster pointer;
    void Start()
    {
        pointer = transform.Find("TeamPointerMaster").gameObject.GetComponent<TeamPointerMaster>();
        battleController = GameObject.Find("BattleController").GetComponent<BattleController>();
        atackScript = GameObject.Find("Batalla").GetComponent<Atack>();

        menu = gameObject;

        setOptions();
    }

    // Update is called once per frame
    void Update()
    {
        input = GetInput();

        if(input != menuInput.None)
        {
            switch (input)
            {
                case menuInput.Up:
                    if (currOption == 2) selectOption(1);
                    break;
                case menuInput.Down:
                    if (currOption == 1) selectOption(2);
                    break;
                case menuInput.Yes:
                    battleController.active = true;

                    updateCoremon(currOption);
                    updateOptions(currOption);
                    
                    menu.SetActive(false);
                    //change Coremon
                    break;
                case menuInput.No:
                    battleController.active = true;
                    menu.SetActive(false);
                    //Go back
                    break;
            }
        }
    }

    menuInput GetInput()
    {
        menuInput menuIn = menuInput.None;

        if(Input.GetAxis("Vertical") > 0)
        {
            menuIn = menuInput.Up;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            menuIn = menuInput.Down;
        }
        else if(Input.GetButtonDown("Submit"))
        {
            menuIn = menuInput.Yes;
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            menuIn = menuInput.No;
        }

        return menuIn;
    }

    void setOptions()
    {
        optionsAvailable[0] = 1;          //Battle starts with coremon at index 0 out, so available options are Coremon
        optionsAvailable[1] = 2;          //At indexes 1 and 2
    }

    void selectOption(int index)
    {
        currOption = index;
        pointer.selectOption(index);
    }

    void updateOptions(int selectedOption)
    {
        selectedOption = optionsAvailable[selectedOption - 1];  //convert selected option to its corresponding Coremon index

        int op1 = -1; //-1 indicates it holds no value
        int op2 = -1;
        int i = 0;

        while(i < 3)  //Cycle through existing indexes
        {
            if(i != selectedOption)  //If index does not correspond to Cor now in battle
            {
                Debug.Log(i);
                if(op1 == -1)
                {
                    op1 = i;      //If op1 holds default value, assign index to op1
                }
                else
                { 
                    op2 = i;      //If op1 is holding an index, assign index to op2
                }
            }

            i++;
        }

        //Save indexes
        optionsAvailable[0] = op1;
        optionsAvailable[1] = op2;
    }

    void updateCoremon(int selectedOption)
    {
        selectedOption = optionsAvailable[selectedOption - 1];  //convert selected option to its corresponding Coremon index
        Debug.Log(selectedOption);
        atackScript.cor = GameData.saveData.team[selectedOption];
    }
    enum menuInput
    {
        None,
        Up,
        Down,
        Yes,
        No
    }
}
