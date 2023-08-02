using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public int Damage;
    public PlayerHealth playerHealth;

   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(Damage);
        }
    }
}
