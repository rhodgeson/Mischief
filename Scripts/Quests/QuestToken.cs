using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestToken : MonoBehaviour
{
    private MainQuestManager q;

    private TokenManager tokenManager;
    void Start()
    {
        q = GameObject.Find("Player").GetComponent<MainQuestManager>();
        tokenManager = GameObject.Find("TokenCount").GetComponent<TokenManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Level1Token")
            {
                q.addLevel1();
            }
            else if (gameObject.tag == "Level2Token")
            {
                q.addLevel2();
            }
            else
            {
                q.addLevel3();
            }

            Destroy(gameObject);
        }
    }
}
