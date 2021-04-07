using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueStorage : MonoBehaviour
{
    MainQuestManager quest;
    PlayerBehaviors pb;

    public GameObject dialogueBox;
    public Text dialogueText;
    void Start()
    {
        dialogueBox.SetActive(false);
        quest = GameObject.Find("Player").GetComponent<MainQuestManager>();
        pb = GameObject.Find("Player").GetComponent<PlayerBehaviors>();
    }

    void Update()
    {

    }

    public void startDialogue(string objName)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = callDialogue(gameObject.name, false);
    }

    public void stopDialogue(string objName)
    {
        dialogueBox.SetActive(false);
        dialogueText.text = callDialogue(gameObject.name, false);
    }

    public string callDialogue(string objName, bool questSolved)
    {
        if (objName.Equals("EndLevel1Sign"))
        {
            return "You collected " + quest.level1Q + " apples for the villagers! You'll surely get your castle back now.";
        }
        else if (objName.Equals("StartLevel1Sign"))
        {
            return "The villagers are having a fruit shortage! I'm sure they'd appreciate some apples this time of year.";
        }
        else if (objName.Equals("DontEatMe"))
        {
            return "Boy am I still hungry... Guess I'll press E.";
        }
        else if (objName.Equals("TutorialTree"))
        {
            return "Press F to burn.";
        }
        else if (objName.Equals("RunVillager"))
        {
            if (!questSolved)
            {
                return "I wish this tree was out of my way so I could get my weekly sprints in..";
            }
            else
            {
                return "Yay! Sprint time!!";
            }

        }
        else if (objName.Equals("Castle"))
        {
            return "How I miss my castle. If I can get the villagers to like me, maybe they'll let me have it back.. I'm still hungry tho";
        }
        else if (objName.Equals("EndVillager"))
        {
            pb.changeKarma(10);
            return "Oh wow thanks Mischief! I love apples.";
        }
        else if (objName.Equals("KarmaDeath"))
        {
            return "Oh no! The villagers banished you from the town!";
        }
        else if (objName.Equals("HungerDeath"))
        {
            return "Your hunger ran out!";
        }
        return "returning";
    }
}
