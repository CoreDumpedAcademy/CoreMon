using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoremonController : MonoBehaviour
{
    // Class that collects functions relating to Coremon
    // Coremon Class is exclusively used to store data
    int maxStatIncrease = 3;

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

    public void levelUp(Coremon mon)
    {
        mon.Level++;
        levelUpIncreaseStats(mon);
    }
    private void levelUpIncreaseStats( Coremon mon )
    {
        int hpIncrease = Random.Range(0, maxStatIncrease  + 1); // Function is not inclusive of top's value, hence the "+1"
        int attackIncrease = Random.Range(0, maxStatIncrease + 1);
        int defenseIncrease = Random.Range(0, maxStatIncrease + 1);
        int speedIncrease = Random.Range(0, maxStatIncrease + 1);

        mon.Ps += hpIncrease;
        mon.Dam += attackIncrease;
        mon.Def += defenseIncrease;
        mon.Vel += speedIncrease;
    }
}
