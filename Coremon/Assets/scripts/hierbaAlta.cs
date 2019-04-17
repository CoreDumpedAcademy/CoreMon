using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class hierbaAlta : MonoBehaviour
{
    float suerte = 0f;
    float probCoremon = 10f;
    GameObject map;
    Grid grid;
    Vector3Int gridPos;
    Vector3Int newGridPos;
    Tilemap collTileMap;          //Grass tile map being collided with
    //TileBase collTile;             //Tile player is now standing in


    private void Start()
    {
        map = GameObject.Find("map");                                            //Retreive scene map
        collTileMap = map.transform.Find("grass").GetComponent<Tilemap>();       //Retrieve grass tilemap
        grid = collTileMap.layoutGrid;                                           //Grid the grass tilemap uses 
    }


    private void OnTriggerStay2D(Collider2D other) 
    {
        

        if (other.gameObject.tag == "hierba")
        {
            //Debug.Log("col");

            newGridPos = grid.WorldToCell(transform.position);

            if(gridPos != newGridPos)                     //If postion in grid is different from before
            {

                gridPos = newGridPos;
                //Debug.Log("OtherTile");
                
                //Apperance probability
                suerte = Mathf.Round(Random.Range(0f, 100f));  

                if (suerte <= probCoremon)
                {
                    Debug.Log("Pokemon apears");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");            //Load battle scene
                    //probCoremon = 5f;               //Probability of appearance is static
                }
            }

            //Debug.Log("inside: " + other.gameObject.GetInstanceID() + " prob: " + probCoremon);

        }

    }

}