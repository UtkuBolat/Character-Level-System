using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<Playerhealth>().Damage(damage);
        Destroy(gameObject);
        




    }
    
}
