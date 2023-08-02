using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{

    [SerializeField] private float secondsToDestroy = 2f;
    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }

   
}
