using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerFlip : MonoBehaviour
{
    public Animator anim;
    private VillagerController vm;
    void Start()
    {
        vm = gameObject.GetComponent<VillagerController>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void flipVillager()
    {
        if (vm.facingRight)
        {
            vm.facingRight = false;
        }
        else
        {
            vm.facingRight = true;
        }
    }

}
