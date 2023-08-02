using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class triggerdoor : DetectionZone
{
    
    public string DoorOpenAnimatorParamName = "DoorOpen";

    Animator animator;
    public Collider colider;



    void Start()
    {
       
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (detectedObjs.Count > 0)
        {
            animator.SetBool(DoorOpenAnimatorParamName, false);
        }
        else
        {
            animator.SetBool(DoorOpenAnimatorParamName, true);
        }
    }
}
