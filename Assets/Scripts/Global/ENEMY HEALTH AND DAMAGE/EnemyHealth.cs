using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int Health = 10;

    void Start()
    {
        maxHealth = Health;
    }

    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health<0)
        {
            Destroy(gameObject);
        }
    }
}
