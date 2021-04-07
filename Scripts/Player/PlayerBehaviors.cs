using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//holds the different methods to be called on regarding the player
public class PlayerBehaviors : MonoBehaviour
{
    //variables can be changed to public if needed
    public float maxHunger = 100f;
    public float maxKarma = 100f;

    [Range(0f, 100f)]
    public float curHunger; //maybe out of 20?

    [Range(0f, 100f)]
    public float curKarma;

    public HungerBar_Script hungerBar;
    public HungerBar_Script karmaBar;


    private int lives;

    DialogueStorage ds;
    public PlayerMovement pm;
    public Animator anim;
    private GameObject[] villager;
    private float posDifference, posDifferenceY;
    private bool vfacingRight;
    public string villagerTouchName = "";
    void Start()
    {
        //Set bars to max
        curHunger = 50f;
        curKarma = 50f;

        hungerBar.SetMaxHunger(maxHunger);
        karmaBar.SetMaxHunger(maxKarma);
        ds = gameObject.GetComponent<DialogueStorage>();
    }

    void Update()
    {
        karmaBar.SetHunger(curKarma);
        // Hunger decreases with time as long as curHunger >= 0. Rate of decrease can be changed.
        if (curHunger > 0)
        {
            curHunger -= .7f * Time.deltaTime;
            hungerBar.SetHunger(curHunger);
        }

        if (curHunger <= 0)
        {
            death("hunger");
        }
        else if (curKarma <= 0)
        {
            death("karma");
        }
    }

    public void eat()
    {
        //play eat animation

        //add to hunger
        if (curHunger <= 100f)
        {
            curHunger += 20;
            if (curHunger > 100f)
                curHunger = 100;
            hungerBar.SetHunger(curHunger);

        }

        //if another villager is looking, lose karma
        villager = GameObject.FindGameObjectsWithTag("Villager");

        foreach (GameObject v in villager)
        {
            vfacingRight = v.GetComponent<VillagerMovement>() != null ? v.GetComponent<VillagerMovement>().facingRight : v.GetComponent<VillagerController>().facingRight;
            posDifference = v.transform.position.x - gameObject.transform.position.x;
            posDifferenceY = v.transform.position.y - gameObject.transform.position.y;
            if (!villagerTouchName.Equals(v.name))
            {
                if ((posDifference < 2.2 && posDifference > 0 && !vfacingRight) || (posDifference < 0 && posDifference > -2.2 && vfacingRight))
                {
                    if (posDifferenceY < 1 && posDifferenceY > -1)
                    {

                        Debug.Log("CAUGHT");
                        Debug.Log(v.gameObject.name);
                        //caught sound
                        changeKarma(-15);
                    }
                }
            }

        }
    }

    public void fire()
    {
        //plays fire animation

    }

    public void death(string deathType)
    {
        //restart level immediately
        if (deathType.Equals("karma"))
        {
            ds.callDialogue("KarmaDeath", false);
        }
        else if (deathType.Equals("hunger"))
        {
            ds.callDialogue("HungerDeath", false);
        }
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //increase or decrease karma
    public void changeKarma(int value)
    {
        if (curKarma < 100f)
        {
            curKarma += value;
            if (curKarma > 100f)
                curKarma = 100;
            karmaBar.SetHunger(curKarma);
        }

    }
}
