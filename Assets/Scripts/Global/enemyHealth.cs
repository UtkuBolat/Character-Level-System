using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int Health = 10;
    public int CurrentHealth=10;
    void Start()
    {
        Health = CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0)
        { 
        Destroy(gameObject);
        }
        
    }
    public void damageEnemy(int damage)
    {
        CurrentHealth -= damage;
    }
}
