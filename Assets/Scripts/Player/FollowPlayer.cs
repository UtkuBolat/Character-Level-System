using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Camera;
    private Vector3 offset = new Vector3(0, 0, -4);
    void Update()
    {
        transform.position = Camera.transform.position +offset;
    }
}
