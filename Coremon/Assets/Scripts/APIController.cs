using System.Net;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

public class APIController : MonoBehaviour
{

    public UserInfo saveData;

    public string[][] test = new string[10][];

    private void Start()
    {
        string user = "nyan3";

        saveData = getSaveData(user);

        Debug.Log(saveData.bag);
    }

    public UserInfo getSaveData(string username)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:3000/users/username&{0}", username));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string jsonResponse = reader.ReadToEnd();

        Debug.Log(jsonResponse);
        UserResponse userRes = JsonUtility.FromJson<UserResponse>(jsonResponse);

        Debug.Log(userRes.user.bag);

        return userRes.user;
    }
}


//Define in main game controller


[Serializable]
public class UserResponse
{
    public UserInfo user;
}

[Serializable]
public class Item
{
    public string name;
    public int amount;
}

[Serializable]
public class Coremon
{
    public string name;
}

[Serializable]
public class UserInfo
{
    public string username;
    public int[] coredex;
    public int money;
    public Item[] bag;
    public Coremon[] team;
}