using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public int Health = 1;
    public int CurrentHealth = 1;
    Animator animator;
    void Start()
    {
        Health = CurrentHealth;
    }

    
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            animator.SetBool("bulletÝs",true);
        }

    }
    public void damageEnemy(int damage)
    {
        CurrentHealth -= damage;
    }
}
