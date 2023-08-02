using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    public int playerHealth;
    public Animator animator;
    
   

    [SerializeField] private Image[] hearts;

    private void Start()
    {
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        if(playerHealth<=0) 
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject);
        }

        for(int i = 0; i< hearts.Length; i++) 
        { 
        if (i< playerHealth) 
            {
                hearts[i].color = Color.red;
            
            }
            else
            {
                hearts[i].color = Color.black;
            }
        
        }
        
    }
    public  void Damage(int Damage)
    {
        playerHealth -= Damage;
        UpdateHealth();

    }
}
