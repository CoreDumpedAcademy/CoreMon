using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.IO;
using System;
using UnityEngine;

public class APIController : MonoBehaviour
{

    public UserInfo saveData;

    //FOR TESTING

    private void Start()
    {
        string user = "nyan3";

        saveData = loadSaveData(user);

        saveData.coredex[29] = 1;
        saveData.money = 300;
        saveData.team[0].Atacks[0].Power = 99;
        
        saveSaveData(saveData);
    }



    //API GET request to load user's save data after authoritation
    //Makes call to asynchronous function to make an asynchronous request
    public UserInfo loadSaveData(string user)
    {
        Task<UserInfo> task = Task.Run<UserInfo>(async () => await getSaveData(user));  //Non scalable solution. Creates new thread. Works for now.

        foreach (Coremon mon in task.Result.team)
        {
            ReadyCoremon(mon);
        }

        return task.Result;
    }

    //Makes the asynchronous call to the API
    public async Task<UserInfo> getSaveData(string username)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost:3000/users/username&{0}", username));
        HttpWebResponse response = (HttpWebResponse)( await request.GetResponseAsync() );
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string jsonResponse = reader.ReadToEnd();

        Debug.Log(jsonResponse);
        UserResponse userRes = JsonUtility.FromJson<UserResponse>(jsonResponse);

        return userRes.user;
    }


    //API PUT request to update the save data
    public void saveSaveData(UserInfo update)
    {
        string json = JsonUtility.ToJson(update);
        byte[] data = Encoding.ASCII.GetBytes(json);
        Uri uri = new Uri(string.Format("http://localhost:3000/users/username&{0}", update.username));

        using(var client = new System.Net.WebClient())
        {
            client.Headers.Add("Content-Type", "application/json");
            client.UploadDataAsync(uri, "PUT", data);                   //May halt things, not sure if it properly implements asynchronity
        }                                                                 
    }

    //Makes Coremon retreived from the database ready to be used in game
    private void ReadyCoremon(Coremon mon)
    {
        CoremonController.setLvlUpExp(mon);
        //mon.Ps = mon.PsMax;
    }
    /*
    public void createSaveData()
    {
        //Not necessary right now
    }
    */  
}



[Serializable]
public class UserResponse
{
    public UserInfo user;
}

//Define in main game controller (maybe)
[Serializable]
public class Item
{
    public string name;
    public int amount;
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