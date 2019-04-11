using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coremonsalvaje : MonoBehaviour
{
    public int coremon = 0;
    // Start is called before the first frame update
    void Start()
    {
        coremonNuevo();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void coremonNuevo()
    {
        int coremon = Random.Range(0, 29);
    }
}
