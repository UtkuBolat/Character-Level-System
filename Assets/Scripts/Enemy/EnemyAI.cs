using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 2f;
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject floatingTextPrefab;
    public GameObject bulletPrefab;
    public GameObject bulletParentObject;
    private Transform player;
    private float nextFireTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
            Instantiate(bulletPrefab, bulletParentObject.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        ShowDamage(damage.ToString());
        health -= damage;
        if (health <= 0)
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

    void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
           GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
           prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
}
