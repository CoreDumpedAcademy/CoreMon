using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float move = 0.1f;
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + move, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - move, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + move);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - move);
        }
    }
}