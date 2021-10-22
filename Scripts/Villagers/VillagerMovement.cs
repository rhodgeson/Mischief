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
    SpriteRenderer spr;

    private bool sprFaceRight;
    void Start()
    {
        leftPoint = transform.position.x;
        rightPoint = transform.position.x + distance;
        Debug.Log(leftPoint);
        Debug.Log(rightPoint);
        lastPoint = transform.position.x;
        spr = gameObject.GetComponent<SpriteRenderer>();
        if (facingRight)
        {
            sprFaceRight = spr.flipX;
        }
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time * 2, rightPoint - leftPoint) + leftPoint, transform.position.y);

        if (transform.position.x > lastPoint)
        {
            facingRight = true;
            spr.flipX = sprFaceRight;
        }
        else
        {
            facingRight = false;
            spr.flipX = (!sprFaceRight);
        }
        lastPoint = transform.position.x;
    }


}
