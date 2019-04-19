

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //Class that stores in memory persistent game information
    //using static fields

    public static UserInfo saveData;

    public static GameObject player;
    public static Vector3Int playerPos;       //Player position before entering battle
}
