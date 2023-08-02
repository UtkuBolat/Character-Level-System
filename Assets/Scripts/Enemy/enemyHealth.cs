using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject floatingTextPrefabs;

    public void TakeDamage(int damage)
    {
        ShowDamage(damage.ToString());
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ShowDamage(string text)
    {
        if (floatingTextPrefabs)
        {
            GameObject prefab = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
}
