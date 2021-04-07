using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//for objects that player can walk through
public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    private string dialogue;
    //private bool playerInRange;
    public bool questFulfilled = false;
    private DialogueStorage ds;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        ds = GameObject.Find("Player").GetComponent<DialogueStorage>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKey(KeyCode.Space) && playerInRange)
        {
            if (DialogueBox.activeInHierarchy)
            {
                DialogueBox.SetActive(false);

            }
            else DialogueBox.SetActive(true);
            dialogueText.text = dialogue;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerInRange = true;
            dialogueBox.SetActive(true);
            dialogueText.text = ds.callDialogue(gameObject.name, questFulfilled);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
