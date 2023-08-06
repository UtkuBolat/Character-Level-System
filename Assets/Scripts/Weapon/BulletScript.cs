using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private float speed = 25;

    [SerializeField] private int bulletDamage;


    private void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.damageEnemy(bulletDamage);
        }
        
        if (collision.gameObject.TryGetComponent<obstacles>(out obstacles obstaclesComponent))
        {

            obstaclesComponent.damageEnemy(bulletDamage);

        }

        if (collision.gameObject.TryGetComponent<SkeletonEnemy>(out SkeletonEnemy skeletonComponent))
        {
            skeletonComponent.damageEnemy(bulletDamage);
        }
        Destroy(gameObject);
        



    }
}
