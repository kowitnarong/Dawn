using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class Enemy1Behavior : MonoBehaviour
    {
        private Transform target;
        private float distance = 3f;
        private float xCenter = 0f;

        void Start()
        {
            target = GetComponent<Transform>();
        }

        void Update()
        {
            transform.position = new Vector3(xCenter + Mathf.PingPong(Time.time * 2, distance) - distance / 2f, transform.position.y, transform.position.z);
        }
    }
}