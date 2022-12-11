using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIgnoreLayer : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(0, 10);
    }
}
