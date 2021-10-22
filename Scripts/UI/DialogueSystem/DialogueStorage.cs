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
        dialogueText.text = callDialogue(objName, false);
    }

    public void stopDialogue(string objName)
    {
        dialogueBox.SetActive(false);
        dialogueText.text = callDialogue(objName, false);
    }

    public string callDialogue(string objName, bool questSolved)
    {
        //into dialogue
        if (objName.Equals("IntroDialogue1"))
        {
            return "(I can't believe the villagers took my castle from me. I'm a dragon. Chaos is all I know!)";
        }
        else if (objName.Equals("IntroDialogue2"))
        {
            return "(I have to get them to like me again. They have to trust me. It's the only way they'll let me have it back.)";
        }
        else if (objName.Equals("IntroDialogue3"))
        {
            return "(My problem is, villagers are the only tasty thing I can find out here. Guess I have to be sneaky...)";
        }
        else if (objName.Equals("StartLevel1Sign"))
        {
            return "The villagers are having an apple shortage! If you can find any, I'm sure they'd appreciate some this time of year.";
        }
        else if (objName.Equals("DontEatMe"))
        {
            return "Press E to eat.";
        }
        else if (objName.Equals("TutorialTree"))
        {
            return "Press F to burn.";
        }
        //quests
        else if (objName.Equals("RunHomeVillager"))
        {
            if (!questSolved)
            {
                return "Can you get rid of that tree so I can get home?";
            }
            else
            {
                return "Yay!! Bye bye tree!!";
            }

        }
        else if (objName.Equals("RunVillager"))
        {
            if (!questSolved)
            {
                return "I wish that tree was out of my way so I could get my weekly sprints in..";
            }
            else
            {
                return "Yay! Sprint time!!";
            }

        }
        else if (objName.Equals("Villager"))
        {
            if (!questSolved)
            {
                return "I wish I had a bridge to get home so I could make it back in time for dinner..";
            }
            else
            {
                return "Yay! Dinnertime! Thanks Mischief!";
            }
        }
        else if (objName.Equals("PushBoxVillager"))
        {
            if (!questSolved)
            {
                return "I wish someone could push that heavy log so our friend could make it over the bridge to hang with us.";
            }
            else
            {
                return "Thanks for helping us out, Mischief!";
            }
        }
        else if (objName.Equals("CampfireVillager"))
        {
            if (!questSolved)
            {
                return "We just can't get this fire to light...";
            }
            else
            {
                return "Yay thanks Mischief!";
            }
        }
        else if (objName.Equals("CampfireVillager2"))
        {
            if (!questSolved)
            {
                return "Hey Mischief! Could you light this fire for us?";
            }
            else
            {
                return "Wooooo! Fire time!";
            }
        }
        else if (objName.Equals("EndVillager"))
        {
            return "Wow thanks for the apples Mischief! We've been starving.";
        }
        //powerup
        else if (objName.Equals("PowerUp1"))
        {
            return "You're invisible now!";
        }
        //caste intro
        else if (objName.Equals("CastleIntro1"))
        {
            return "(Finally got my castle back -- Uh oh... I forgot about all the traps I had set in here.)";
        }
        else if (objName.Equals("CastleIntro2"))
        {
            return "(They're meant to keep others out, but I guess now I have to survive them too.)";
        }
        else if (objName.Equals("CastleEnd1"))
        {
            return "(FINALLY! My secret stash! Truth is, I never really liked the taste of villagers all that much, and I HATE apples.)";
        }
        else if (objName.Equals("CastleEnd2"))
        {
            return "(What I really wanted was my pineapples, but since they kicked me out, I had no other choice... But yay! Home sweet home at last!!)";
        }
        return "";
    }
}
