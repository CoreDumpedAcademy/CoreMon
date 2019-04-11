using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuevoCoremon : MonoBehaviour
{

    int prob;

    public void start()
    {
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
            SceneManager.LoadScene("Battle");
        }
    }
}