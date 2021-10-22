using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//idea: main quest for each level. maybe have to count up to something?
//so can have a variable that tracks once it gets to a certain number
//if touching the end of the level and the quest variable is a certain #, you win
public class MainQuestManager : MonoBehaviour
{
    public int level1Q = 0;
    public int level2Q = 0;
    public int level3Q = 0;

    ScoreManager scoreMan;
    GameObject score;

    void Start()
    {
      score = GameObject.Find("Score");
      if(score != null)
        scoreMan = score.GetComponent<ScoreManager>();
    }


    public void addLevel1()
    {
        level1Q += 1;
        scoreMan.updateScore(10);
        Debug.Log(level1Q);
    }

    public void addLevel2()
    {
        level2Q += 1;
    }

    public void addLevel3()
    {
        level3Q += 1;
    }
}
