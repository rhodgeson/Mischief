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
    ScoreManager scoreMan;

    private int lives;
    int curKarmaInt;

    DialogueStorage ds;
    public PlayerMovement pm;
    public Animator anim;
    private GameObject[] villager;
    private float posDifference, posDifferenceY;
    //public float delay;
    private bool vfacingRight;
    public string villagerTouchName = "";
    public string currentLevel;
    LifeManager lifem;
    //public Exclamation_Script Exclamation;
    private bool invisible;
    private PowerUp pow;

    void Start()
    {
        //Set bars to half
        curHunger = 75f;
        curKarma = 50f;

        hungerBar.SetMaxHunger(maxHunger);
        if (karmaBar != null)
            karmaBar.SetMaxHunger(maxKarma);
        ds = gameObject.GetComponent<DialogueStorage>();
        lifem = FindObjectOfType<LifeManager>();
        scoreMan = FindObjectOfType<ScoreManager>();

        PlayerPrefs.SetString("curLevel", SceneManager.GetActiveScene().name);
        currentLevel = PlayerPrefs.GetString("curLevel");


        PlayerPrefs.SetInt("playerCurScore", 0);
        pow = gameObject.GetComponent<PowerUp>();
    }

    void Update()
    {
        if (pow.invisible)
        {
            invisible = true;
        }
        else if (!pow.invisible)
        {
            invisible = false;
        }

        if (karmaBar != null)
            karmaBar.SetHunger(curKarma);
        // Hunger decreases with time as long as curHunger >= 0. Rate of decrease can be changed.
        if (curHunger > 0)
        {
            curHunger -= 1.5f * Time.deltaTime;
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
        gameObject.GetComponent<PlayerSoundManager>().eatSound.Play();
        //add to hunger
        if (curHunger <= 100f)
        {
            curHunger += 10;
            if (curHunger > 100f)
                curHunger = 100;
            hungerBar.SetHunger(curHunger);

        }
        if (!invisible)
        {
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
                            v.GetComponent<Exclamation_Script>().ShowAndHide();
                            changeKarma(-15);
                        }
                    }
                }

            }
        }
    }

    public void fire()
    {
        //plays fire animation
        if (!invisible)
        {
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
                            v.GetComponent<Exclamation_Script>().ShowAndHide();
                            changeKarma(-15);
                        }
                    }
                }

            }
        }
    }


    public void death(string deathType)
    {
        gameObject.GetComponent<PlayerSoundManager>().deathSound.Play();
        //restart level 
        if (deathType.Equals("fall"))
        {
            endDeathAnim();
        }
        else
        {

            //calls death animation which then calls endDeathAnim()
            if (pm.facingRight)
            {
                anim.SetTrigger("DieRight");
            }
            else
            {
                anim.SetTrigger("DieLeft");
            }
        }
    }

    public void endDeathAnim()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        lifem.lifeChange(-1);
    }


    //increase or decrease karma
    public void changeKarma(int value)
    {
        if (curKarma < 100f)
        {
            if (value > 0)
            {
                GameObject.Find("Player").GetComponent<PlayerSoundManager>().positiveSound.Play();
            }
            else
            {
                GameObject.Find("Player").GetComponent<PlayerSoundManager>().negativeSound.Play();
            }
            curKarma += value;
            if (curKarma > 100f)
                curKarma = 100;
            karmaBar.SetHunger(curKarma);
            //curKarmaInt = (int) curKarma;

            scoreMan.updateScore(value * 3);
        }

    }
}
