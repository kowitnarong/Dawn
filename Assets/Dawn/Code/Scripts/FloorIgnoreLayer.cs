using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class FloorIgnoreLayer : MonoBehaviour
    {
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Physics.IgnoreLayerCollision(9, 10);
        }
    }
}