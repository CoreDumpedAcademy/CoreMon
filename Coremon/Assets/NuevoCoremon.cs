using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoCoremon : MonoBehaviour
{

    bool newPokemon;
    int prob;

    public void start()
    {
        newPokemon = false;
    }

    public void Update()
    {
     
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "hierba")
        {
            prob++;

        }
    }

    private void appearCoremon()
    {
        if(prob > Random.Range(1,100))
        {
            //Activar escena batalla y script pokemon nuevo
        }
    }
}