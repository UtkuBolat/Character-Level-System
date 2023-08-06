using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyHealth>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}





