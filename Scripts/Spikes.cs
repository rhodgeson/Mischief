using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    PlayerBehaviors pb;
    // Start is called before the first frame update
    void Start()
    {
        pb = GameObject.Find("Player").GetComponent<PlayerBehaviors>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            pb.death("spikes");
        }
    }
}
