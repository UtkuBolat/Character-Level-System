using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float force = 25;
    private Rigidbody2D bulletRB;
    private GameObject target;

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * force;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        //Destroy(this.gameObject, 0.75f);
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y).normalized * force;
        bulletRB.transform.right = bulletRB.velocity.normalized;

    }
}