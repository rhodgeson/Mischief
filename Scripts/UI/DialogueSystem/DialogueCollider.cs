using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//for objects player cannot walk through
public class DialogueCollider : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    private string dialogue;
    // private bool playerInRange;

    public bool questFulfilled = false;

    private DialogueStorage ds;
    void Start()
    {
        dialogueBox.SetActive(false);
        ds = GameObject.Find("Player").GetComponent<DialogueStorage>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerInRange = true;
            dialogueBox.SetActive(true);
            dialogueText.text = ds.callDialogue(gameObject.name, questFulfilled);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
