using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hierbaAlta : MonoBehaviour
{
    float probCoremon = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        probCoremon = Mathf.Round(Random.Range(0f,1000f));

        if(probCoremon <= 50f)
        {
            Debug.Log("Pokemon apears");
        }
    }
}