using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obbstaclesDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<obstacles>().damageEnemy(damage);
        Destroy(gameObject);

    }
}




