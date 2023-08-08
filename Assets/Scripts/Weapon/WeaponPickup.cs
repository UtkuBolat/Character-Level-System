using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    public GameObject weaponPrefab;
    public float pickupDistance = 2.0f;

    private void Update()
    {
        
        if (Input.GetKeyDown(pickupKey) && Vector2.Distance(transform.position, weaponPrefab.transform.position) < pickupDistance)
        {
            Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            Destroy(weaponPrefab); // Yerden silinmesi gerekebilir
        }
    }
}
