using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 velocity;
    Vector3 verticalInput;
    

    float Speed = 5.0f;
    float upspped = 5.0f;
    public Animator animator;
    

    void Start()
    {
      
      
        
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
         verticalInput= new Vector3(0f,Input.GetAxis("Vertical"));
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("upspeed", Mathf.Abs(Input.GetAxis("Vertical")));
        transform.position+= velocity * Speed * Time.deltaTime;
        transform.position+= verticalInput* upspped * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); 
        }
        else if ((Input.GetAxisRaw("Horizontal") == 1))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }





    }
}
