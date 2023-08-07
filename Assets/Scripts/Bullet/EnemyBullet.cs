using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float force = 25;
    private Rigidbody2D bulletRB;
    private GameObject target;
    [SerializeField] int damage=10;

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * force;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 1f);
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y).normalized * force;
        bulletRB.transform.right = bulletRB.velocity.normalized;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController component))
        {
            component.TakeDamage(damage);

            
        }

        if (component)
        {
            Destroy(gameObject);
        }
    }
}