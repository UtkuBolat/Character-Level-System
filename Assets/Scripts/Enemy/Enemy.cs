using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //---------------------Enemy AI -----------------------
    private float speed =2f;
    private float lineOfSight=4.43f;
    private float shootingRange=2.43f;
    private float fireRate = 2f;
    [Header("Enemy AI")]
    [SerializeField]private GameObject floatingTextPrefab;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject bulletParentObject;
    [SerializeField]private Transform player;
    [SerializeField]private float nextFireTime;
    //----------------------Enemy Health---------------------
    [Header("EnemyHealth")]
    [SerializeField] private int Health = 10;
    [SerializeField] private int CurrentHealth = 10;
 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth();
    }

    private void Update()
    {
        enemyAI();
        die();
    }

    void enemyAI()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bulletPrefab, bulletParentObject.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }
    
    void enemyHealth ()
    {
        CurrentHealth = Health;
    }

    public void damageEnemy(int damage)
    {
     CurrentHealth -= damage;
    }

    public void die()
    {
      if (CurrentHealth <= 0)
    {

    Destroy(gameObject);


    }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

}
