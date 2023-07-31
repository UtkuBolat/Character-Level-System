using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public Transform obstacle;
    public Transform Bullet;
    public float bulletis;
    public float box›s = 0.1f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletis = Vector2.Distance(transform.position, Bullet.position);
        if (bulletis != box›s) 
        {
            animator.SetBool("bullet›s", true);
        }
        else
        {
            animator.SetBool("bullet›s", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, box›s);
    }
}
