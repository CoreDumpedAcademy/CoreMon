using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameData.player = this.gameObject;

        if (GameData.playerPos == null)
        {
            transform.position = Vector3Int.zero;
        }
        else
        {
            transform.position = GameData.playerPos;
        }
    }

}