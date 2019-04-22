using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoremonController : MonoBehaviour
{
    // Class that collects functions relating to Coremon
    // Coremon Class is exclusively used to store data

    int maxStatIncrease = 3;                 //Max amount of points each stat is able to increase each level up
    int maxLvl = 40;


    static int initialLvlUpExp = 15;                //Exp points necessary to level up from lvl.1 to lvl.2
    static float lvlUpExpIncreaseFactor = 0.15f;    //Amount by which the exp necessary for leveling up increases

    int baseRewardLevel = 5;                 //Balancing assumes that an enemy at  level: baseRewardLevel 
    int baseRewardExp = 100;                 //drops an exp point reward of: baseRewardExp 


    /*     FOR TESTING.   CHECK BEHAVOUR WITH EDITOR ON DEBUG MODE 
    public Coremon test;
    public Coremon test1;
    public Coremon test2;
    public Coremon test3;
    public Coremon test4;
    private void Start()
    {
        test = new Coremon();
        Coremon enemy = new Coremon();
        enemy.Level = 10;
        test1 = new Coremon();
        test2 = new Coremon();
        test3 = new Coremon();
        test4 = new Coremon();
        
        for (int i = 0; i < 500; i++)
        {
            applyExpRewardExp(test, enemy);
        }


    }
    */

    /*
     *   Leveling up function. Start
     */
    public void levelUp(Coremon mon)
    {
        if(mon.Level < maxLvl)
        {
            mon.Level++;
            mon.ExpPoints = 0;              //Reset experience points 
            increaseLvlUpExp(mon);          //Increase experience necessary to level up
            levelUpIncreaseStats(mon);      //Apply stat increase at level up
        }
    }
    private void levelUpIncreaseStats( Coremon mon )       //Only called from levelUp function
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

    private void increaseLvlUpExp(Coremon mon)            //Only called from levelUp function
    {
        // lvlUpExp += lvlUpExp * increaseFactor
        mon.LvlUpExp += Mathf.CeilToInt(mon.LvlUpExp * lvlUpExpIncreaseFactor); 
    }

    //Function to set the lvlUpExp property to coremon read from database
    public void setLvlUpExp(Coremon mon)
    {
        int ExpGauge = -1;  //Default for invalid level

        if(mon.Level == 1)
        {
            ExpGauge = initialLvlUpExp;  //Set initial value at lvl 1 
        }else if(mon.Level > 1)
        {
            //lvlUpExp = initialExp * ( 1 + increaseFactor ) ^ level
            Debug.Log(Mathf.Pow(lvlUpExpIncreaseFactor, mon.Level));
            ExpGauge = Mathf.CeilToInt(initialLvlUpExp * Mathf.Pow( 1 + lvlUpExpIncreaseFactor, mon.Level));
        }

        mon.LvlUpExp = ExpGauge;
    }

    /*
    *   Leveling up functions. End
    */
    public Sprite getCoremonSprite(Coremon cor)
    {
        string index;
        if(cor.NumCoremon < 10 && cor.NumCoremon > 0)
        {
            index = "0" + cor.NumCoremon.ToString();
        }
        else
        {
            index = cor.NumCoremon.ToString();
        }

        Debug.Log(index);
        Sprite sprite = Resources.Load<Sprite>(@"Sprite Coremon\" + index);
        Debug.Log(sprite);

        return sprite;
    }
    
    //Getsa coremon from the data base using its index
    public Coremon getCoremonNum(int num)
    {
        Coremon cor = null;
        if (num >= 1 && num <= 30)
        {
            cor = GameData.CoremonData[num - 1];
            cor.Ps = cor.PsMax;
            setLvlUpExp(cor);
            cor.sprite = getCoremonSprite(cor);
        }
        return cor;
    }


    public Coremon getWildCoremon()
    {
        int index = UnityEngine.Random.Range(0, 30);
        return getCoremonNum(index);
    }

    /* Function to apply the exp reward dropped by an enemy */
    public void applyExpRewardExp(Coremon mon, Coremon enemy)
    {
        if (mon.Level < maxLvl) //skip if its called for a mon at max level
        {
            int reward = 1;           //Default if enemy level is no valid
            int newExpAmmount;

            //calculate reward if enemy level is valid
            if (enemy.Level > 0)
            {
                reward = baseRewardExp * (enemy.Level / baseRewardLevel);
            }
        
            newExpAmmount = mon.ExpPoints + reward;   //Sees how much exp will the mon gain
            
            if (newExpAmmount >= mon.LvlUpExp)      //If it's enoguht to level up
            {
                do
                {
                    newExpAmmount = newExpAmmount - mon.LvlUpExp;      //Calculates exp points left after leveling up
                    levelUp(mon);

                } while (newExpAmmount >= mon.LvlUpExp);               //if exp left is enough to level up once more    
            }
            else                                    //If it's not enought to level up
            {
                mon.ExpPoints = newExpAmmount;
            }
        }
        
    }

}


[Serializable]
public class Coremon
{
    public string name;
    public Sprite sprite;
    public string Type;
    public int NumCoremon;
    public int Level;
    public int ExpPoints;
    public int LvlUpExp;
    public int PsMax;
    public int Ps;
    public int Dam;
    public int Def;
    public int Vel;
    public Attack[] Atacks;


    public Coremon(){
        this.name = "test";
        this.Type = "Planta";
        this.NumCoremon = 1;
        this.Level = 1;
        this.ExpPoints = 0;
        //CoremonController.setLvlUpExp(this);
        this.PsMax = 1;
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