using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float gridSize = 1f;
    public float moveSpeed = 0.2f;

    private Vector3 destination;
    private Vector3 dir;
    private Vector3 distance = Vector3.zero;

    void Start()
    {

    }

    void FixedUpdate()
    {

        if(dir == Vector3.zero)
        {
            //Get the direction to move
            if (Input.GetKey(KeyCode.D))
            {
                destination = transform.position + Vector3.right * gridSize;
                dir = Vector3.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                destination = transform.position + Vector3.left * gridSize;
                dir = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                destination = transform.position + Vector3.up * gridSize;
                dir = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                destination = transform.position + Vector3.down * gridSize;
                dir = Vector3.down;
            }
        } else
        {
            //Move if stored direction

            distance = destination - transform.position; //vector distance
            transform.Translate(dir * moveSpeed);
            if (dir == Vector3.right)
            {
                if (distance.x < moveSpeed)
                {
                    dir = Vector3.zero;
                    transform.position = destination;
                }
            }
            else if (dir == Vector3.left)
            {
                if (distance.x > -moveSpeed)
                {
                    dir = Vector3.zero;
                    transform.position = destination;
                }
            }
            else if (dir == Vector3.down)
            {
                if (distance.y > -moveSpeed)
                {
                    dir = Vector3.zero;
                    transform.position = destination;
                }
            }
            else if (dir == Vector3.up)
            {
                if (distance.y < moveSpeed)
                {
                    dir = Vector3.zero;
                    transform.position = destination;
                }
            }
        }
    }
}