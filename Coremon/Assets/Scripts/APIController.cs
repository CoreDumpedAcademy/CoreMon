using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using UnityEngine;

public class APIController : MonoBehaviour
{

    public UserInfo saveData;

    private void Start()
    {
        string user = "nyan3";

        saveData = loadSaveData(user);

        Debug.Log(saveData.bag);
    }


    public UserInfo loadSaveData(string user)
    {
        Task<UserInfo> task = Task.Run<UserInfo>(async () => await getSaveData(user));  //Non scalable solution. Creates new thread. Works for now.
        return task.Result;
    }

    public async Task<UserInfo> getSaveData(string username)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:3000/users/username&{0}", username));
        HttpWebResponse response = (HttpWebResponse)( await request.GetResponseAsync() );
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