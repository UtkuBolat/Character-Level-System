using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SkeletonEnemy : MonoBehaviour
{
    float lineOfSight = 4.53f;
    float speed = 3.5f;
    Transform player;
    [Header("EnemyAnimation")]
    public Animator animator;
    [Header("EnemyHealth")]
    [SerializeField] private int Health = 10;
    [SerializeField] private int CurrentHealth = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        skeletonHealth();
    }

    
    void Update()
    {

        skeletonAI();
        die();


    }

    void skeletonAI()
    {

        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceFromPlayer <= 4.53f)
        {

            animator.SetBool("enemyis", true);
        }
        else
        {
            animator.SetBool("enemyis", false);
        }

        if (distanceFromPlayer <= 1f)
        {
            animator.SetBool("enemyFight", true);

        }
        else
        {
            animator.SetBool("enemyFight", false);
        }


        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (distanceFromPlayer <= lineOfSight)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
    }

    void skeletonHealth()
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
