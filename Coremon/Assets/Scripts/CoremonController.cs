using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoremonController : MonoBehaviour
{
    // Class that collects functions relating to Coremon
    // Coremon Class is exclusively used to store data


    int maxStatIncrease = 3; //Max amount of points each stat is able to increase each level up
    

    /*  FOR TESTING.   CHECK BEHAVOUR WITH EDITOR ON DEBUG MODE 
    public Coremon test = new Coremon();
    public Coremon test1 = new Coremon();
    public Coremon test2 = new Coremon();
    public Coremon test3 = new Coremon();
    public Coremon test4 = new Coremon();
    private void Start()
    {
        
        for(int i = 0; i < 10; i++)
        {
            levelUp(test);
            levelUp(test1);
            levelUp(test2);
            levelUp(test3);
            levelUp(test4);
        }
        
    }
    */
    public void levelUp(Coremon mon)
    {
        mon.Level++;
        mon.ExpPoints = 0;
        //Update exp necessary for next level up
        levelUpIncreaseStats(mon);
    }
    private void levelUpIncreaseStats( Coremon mon )
    {
        //Get random increase for each stat
        int hpIncrease = UnityEngine.Random.Range(0, maxStatIncrease  + 1); // Function is not inclusive of top's value, hence the "+1"
        int attackIncrease = UnityEngine.Random.Range(0, maxStatIncrease + 1);
        int defenseIncrease = UnityEngine.Random.Range(0, maxStatIncrease + 1);
        int speedIncrease = UnityEngine.Random.Range(0, maxStatIncrease + 1);

        mon.Ps += hpIncrease;
        mon.Dam += attackIncrease;
        mon.Def += defenseIncrease;
        mon.Vel += speedIncrease;
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
}

[Serializable]
public class Attack
{
    public string name;
    public string Type;
    public int Power;
}