using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public int Health ;
    public int CurrentHealth ;
    public Animator animator;
    void Start()
    {
        Health = CurrentHealth;
    }

    
    void Update()
    {
        if (CurrentHealth<=0)
        {
            animator.SetBool("bulletIs",true);

            Destroy(gameObject, 0.75f);


        }

        

        
        

    }
    public void damageEnemy(int damage)
    {
        CurrentHealth -= damage;
    }
}
