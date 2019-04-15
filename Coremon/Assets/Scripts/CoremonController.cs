using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoremonController : MonoBehaviour
{
    // Class that collects functions relating to Coremon
    // Coremon Class is exclusively used to store data

    public int maxStatIncrease = 3;                 //Max amount of points each stat is able to increase each level up

    static int initialLvlUpExp = 15;                //Exp points necessary to level up from lvl.1 to lvl.2
    static float lvlUpExpIncreaseFactor = 0.15f;    //Amount by which the exp necessary for leveling up increases



    //     FOR TESTING.   CHECK BEHAVOUR WITH EDITOR ON DEBUG MODE 
    public Coremon test;
    public Coremon test1;
    public Coremon test2;
    public Coremon test3;
    public Coremon test4;

    private void Start()
    {
        test = new Coremon();
        test1 = new Coremon();
        test2 = new Coremon();
        test3 = new Coremon();
        test4 = new Coremon();

        for (int i = 0; i < 39; i++)
        {
            levelUp(test);
            levelUp(test1);
            levelUp(test2);
            levelUp(test3);
            levelUp(test4);
        }
        
    }
    
    public void levelUp(Coremon mon)
    {
        mon.Level++;                    
        mon.ExpPoints = 0;              //Reset experience points 
        increaseLvlUpExp(mon);          //Increase experience necessary to level up
        levelUpIncreaseStats(mon);      //Apply stat increase at level up
    }
    private void levelUpIncreaseStats( Coremon mon )
    {
        //Get random increase for each stat
        int hpIncrease = UnityEngine.Random.Range(0, maxStatIncrease  + 1);     // Function is not inclusive of top's value, hence the "+1"
        int attackIncrease = UnityEngine.Random.Range(0, maxStatIncrease + 1);
        int defenseIncrease = UnityEngine.Random.Range(0, maxStatIncrease + 1);
        int speedIncrease = UnityEngine.Random.Range(0, maxStatIncrease + 1);

        //Apply level increase
        mon.Ps += hpIncrease;
        mon.Dam += attackIncrease;
        mon.Def += defenseIncrease;
        mon.Vel += speedIncrease;
    }

    private void increaseLvlUpExp(Coremon mon)
    {
        // lvlUpExp += lvlUpExp * increaseFactor
        mon.LvlUpExp += Mathf.CeilToInt(mon.LvlUpExp * lvlUpExpIncreaseFactor); 
    }

    public static void setLvlUpExp(Coremon mon)
    {
        int ExpGauge = -1;  //Default for invalid level

        if(mon.Level == 1)
        {
            ExpGauge = initialLvlUpExp;  //Set initial value at lvl 1 
        }else if(mon.Level > 1)
        {
            //lvlUpExp = initialExp * increaseFactor ^ level
            ExpGauge = Mathf.CeilToInt(initialLvlUpExp * Mathf.Pow(lvlUpExpIncreaseFactor, mon.Level));
        }

        mon.LvlUpExp = ExpGauge;
    }
}


[Serializable]
public class Coremon
{
    public string name;
    public string Type;
    public int NumCoremon;
    public int Level;
    public int ExpPoints;
    public int LvlUpExp;
    public int Ps;
    public int Dam;
    public int Def;
    public int Vel;
    public Attack[] Atacks;


    public Coremon(){
        this.name = "test";
        this.Type = "Planta";
        this.NumCoremon = 0;
        this.Level = 1;
        this.ExpPoints = 0;
        CoremonController.setLvlUpExp(this);
        this.Ps = 1;
        this.Dam = 1;
        this.Def = 1;
        this.Vel = 1;
        this.Atacks = new Attack[4];
        for (int i = 0; i < 4; i++)
        {
            this.Atacks[i] = new Attack();
        }
    }
}

[Serializable]
public class Attack
{
    public string name;
    public string Type;
    public int Power;

    public Attack()
    {
        this.name = "testA";
        this.Type = "Planta";
        this.Power = 10;
    }
}