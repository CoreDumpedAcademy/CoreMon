using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hierbaAlta : MonoBehaviour
{
    float suerte = 0f;
    float probCoremon = 5f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("col");

        if (other.gameObject.tag == "hierba")
        {
            Debug.Log("inside: " + probCoremon);

            suerte = Mathf.Round(Random.Range(0f, 100f));

            if (suerte <= probCoremon)
            {
                Debug.Log("Pokemon apears");
                probCoremon = 5f;
            }
        }

    }
}