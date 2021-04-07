using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour
{
    DialogueTrigger diag;
    VillagerMovement move;
    private bool canMove, notMoving;

    public bool facingRight;
    void Start()
    {
        move = gameObject.GetComponent<VillagerMovement>();
        diag = gameObject.GetComponent<DialogueTrigger>();
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
            }
        }
        else
        {
            canMove = false;
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
