using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int Damage;
    public PlayerHealth enemyHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy") 
        {
            enemyHealth.TakeDamage(Damage);
        }
    }


}
