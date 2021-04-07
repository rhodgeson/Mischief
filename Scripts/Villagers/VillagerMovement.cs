using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    private float leftPoint = 3f;
    private float rightPoint = 4f;
    public float distance;

    public bool facingRight;
    private float lastPoint;

    void Start()
    {
        leftPoint = transform.position.x;
        rightPoint = transform.position.x + distance;
        Debug.Log(leftPoint);
        Debug.Log(rightPoint);
        lastPoint = transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time * 2, rightPoint - leftPoint) + leftPoint, transform.position.y);

        if (transform.position.x > lastPoint)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
        lastPoint = transform.position.x;
        Debug.Log(facingRight);
        // if (Mathf.Round(transform.position.x * 100.0f) * 0.01f == rightPoint)
        // {
        //     facingRight = false;
        //     Debug.Log("left");
        // }
        // else if (Mathf.Round(transform.position.x * 100.0f) * 0.01f == leftPoint)
        // {
        //     facingRight = true;
        //     Debug.Log("right");
        // }
    }


}
