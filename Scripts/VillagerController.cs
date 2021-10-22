using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour
{
    DialogueTrigger diag;
    VillagerMovement move;
    private bool canMove, notMoving;

    public bool facingRight;
    public bool sprFacingRight;
    SpriteRenderer spr;
    void Start()
    {
        move = gameObject.GetComponent<VillagerMovement>();
        diag = gameObject.GetComponent<DialogueTrigger>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        if (move != null)
        {
            canMove = true;
            if (move.enabled == true)
            {
                notMoving = false;
            }
            else
            {
                notMoving = true;
                if (facingRight)
                {
                    sprFacingRight = spr.flipX;
                }
                else
                {
                    sprFacingRight = !(spr.flipX);
                }
            }
        }
        else
        {
            canMove = false;
            if (facingRight)
            {
                sprFacingRight = spr.flipX;
            }
            else
            {
                sprFacingRight = !(spr.flipX);
            }
        }
    }

    void Update()
    {
        if (!canMove)
        {
            if (facingRight)
            {
                spr.flipX = sprFacingRight;
            }
            else
            {
                spr.flipX = (!sprFacingRight);
            }
        }
    }
    public void eaten()
    {
        //villager eaten (disappears)
        Destroy(gameObject);
    }

    public void fired()
    {
        //villager dies
        Destroy(gameObject);
    }

    public void questSucceed()
    {
        //obj has dialogue
        if (diag != null)
        {
            diag.questFulfilled = true;
        }
        if (canMove && notMoving)
        {
            move.enabled = true;
        }
    }
}
