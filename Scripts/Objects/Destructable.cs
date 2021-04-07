using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public bool onFire = false;
    private int durability = 80;
    public Animator anim;

    public bool sideQuestObj; //if true, destruction of obj adds karma

    public string villagerName; //name of villager this quest helps
    VillagerController villager;
    PlayerBehaviors pb;
    ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("Player").GetComponent<PlayerBehaviors>();
        if (sideQuestObj)
        {
            villager = GameObject.Find(villagerName).GetComponent<VillagerController>();
            score = GameObject.Find("Score").GetComponent<ScoreManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire)
        {
            durability--;
        }
        if (durability < 0)
        {
            if (sideQuestObj  && villager != null)
            {
                villager.questSucceed();
                pb.changeKarma(10);
                score.updateScore(100);
            }
            Destroy(gameObject);
        }
    }

    public void fired()
    {
        onFire = true;
        anim.SetBool("onFire", true);
    }
}
