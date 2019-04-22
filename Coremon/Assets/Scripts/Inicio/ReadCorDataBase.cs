using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCorDataBase : MonoBehaviour
{
    TextAsset JSON;
    CoremonArray coremonData;

    void Start()
    {
        JSON = Resources.Load<TextAsset>("Coredex");
        coremonData = JsonUtility.FromJson<CoremonArray>(JSON.text);
        GameData.CoremonData = coremonData.coredex;
    }
}

[Serializable]
public class CoremonArray
{
    public Coremon[] coredex;
}
