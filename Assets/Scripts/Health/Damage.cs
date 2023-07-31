using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int Damage;
    public PlayerHealth enemyHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            enemyHealth.TakeDamage(Damage);
        }
    }


}
