using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//checks for player input and player state and calls methods from other classes based on that
public class PlayerController : MonoBehaviour
{
    private PlayerBehaviors pb;
    private bool touchingVillager = false;
    private bool touchingDestructable = false;
    private VillagerController villager;
    private Destructable destructable;
    private MainQuestManager q;
    private PlayerMovement pm;
    void Start()
    {
        pb = gameObject.GetComponent<PlayerBehaviors>();
        q = GameObject.Find("Player").GetComponent<MainQuestManager>();
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (touchingVillager)
            {
                //player eats villager
                pb.eat(); //plays eat animation, adds to hunger bar
                villager.eaten(); //villager is eaten
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            //player uses fire attack on villager
            pb.fire(); //plays fire animation, DOESNT add to hunger bar
            pm.fireAnim();
            if (touchingVillager)
            {
                villager.fired(); //villager dies
            }
            else if (touchingDestructable)
            {
                destructable.fired();
            }
        }

        //player falls to his death
        if (gameObject.transform.position.y < -7)
        {
            pb.death("fall");
        }

        // if (touchingVillager)
        // {
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         //player eats villager
        //         pb.eat(); //plays eat animation, adds to hunger bar
        //         villager.eaten(); //villager is eaten
        //     }
        //     else if (Input.GetKeyDown(KeyCode.F))
        //     {
        //         //player uses fire attack on villager
        //         pb.fire(); //plays fire animation, DOESNT add to hunger bar
        //         villager.fired(); //villager dies
        //     }
        // }
        // if (touchingDestructable)
        // {
        //     if (Input.GetKeyDown(KeyCode.F))
        //     {
        //         pb.fire();
        //         destructable.fired();
        //     }
        // }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Villager")
        {
            pb.villagerTouchName = col.gameObject.name;
            touchingVillager = true;
            villager = col.gameObject.GetComponent<VillagerController>();
        }


    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Villager")
        {
            touchingVillager = false;
            villager = null;
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Destructable")
        {
            touchingDestructable = true;
            destructable = col.gameObject.GetComponent<Destructable>();
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Destructable")
        {
            touchingDestructable = false;
            destructable = null;
        }
    }
}
