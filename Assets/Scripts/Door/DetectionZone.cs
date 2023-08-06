using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private string tagTarget = "Player";



    public List<Collider2D> detectedObjs = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            detectedObjs.Add(collision);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget) { detectedObjs.Remove(collision); }



    }
}
