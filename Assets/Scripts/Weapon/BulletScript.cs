using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    public Rigidbody2D rb;
    public float speed = 25;
    

    private void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb=GetComponent<Rigidbody2D>();
        mousePos =mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction= mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        rb.transform.rotation = Quaternion.Euler(0, rot, 0);
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        rb.transform.right = rb.velocity.normalized;
    }
    
}
