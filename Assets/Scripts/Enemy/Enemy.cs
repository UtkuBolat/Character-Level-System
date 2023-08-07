using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int expPoints = 10;
    #region EnemyAI
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
    #endregion

    #region Enemy Health
    [Header("EnemyHealth")]
    [SerializeField] private int Health = 10;
    [SerializeField] private int CurrentHealth = 10;




    #endregion
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyHealth();
    }

    private void Update()
    {
        enemyAI();
        
    }

    #region EnemyAI
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
    #endregion

    #region Enemy Health
    void enemyHealth ()
    {
        CurrentHealth = Health;
    }

    public void damageEnemy(int damage)
    {
     CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

  

    public void Die()
    {
        
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.GainExperiencePoints(expPoints);
        }

        Destroy(gameObject);
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

}
