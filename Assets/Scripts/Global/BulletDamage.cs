using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<enemyHealth>().damageEnemy(bulletDamage);
        Destroy(gameObject);
    }
}
