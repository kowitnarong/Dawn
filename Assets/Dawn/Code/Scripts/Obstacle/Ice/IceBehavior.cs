using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class IceBehavior : MonoBehaviour
    {
        private Rigidbody rb;
        private float distance = 3f;
        private float xCenter = 0f;
        [SerializeField] private float speed = 1f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            xCenter = transform.position.x;
        }

        void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                //rb.MovePosition(new Vector3(Mathf.PingPong(Time.time * distance, distance) + xCenter, transform.position.y, transform.position.z));
                //add speed pingpong left and right
                rb.MovePosition(new Vector3(Mathf.PingPong(Time.time * speed, distance) + xCenter, transform.position.y, transform.position.z));
            }
        }
    }
}