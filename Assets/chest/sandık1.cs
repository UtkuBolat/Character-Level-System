using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public Collider2D colider;
    public GameObject glock;
    

    

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
       
        
    }

    public void chest(bool isOpen)

    {
       
        if (isOpen==true)
        {

            GameObject glocktemp = Instantiate(glock, transform.position, Quaternion.identity) as GameObject;

            animator.SetBool("IsOpen",true);
            Destroy(colider);

        }
        else
        {
            glock.SetActive(false);
            animator.SetBool("IsOpen", false);
        }
    }
 
}
