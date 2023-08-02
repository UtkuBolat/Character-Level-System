using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class denemeai : MonoBehaviour
{
    float lineOfSight = 4.53f;
    float speed = 3.5f;
    Transform player;
    public Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    
    void Update()
    {
       
        
            float distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceFromPlayer <= 4.53f)
        {

            animator.SetBool("enemyis", true);
        }
        else
        {
            animator.SetBool("enemyis", false);
        }

        if(distanceFromPlayer <= 1f)
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
