using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class ForwardBackwardAlongYAxisMovement : MonoBehaviour
    {
        //Move pingpong Y axis
        public float speed = 1f;
        public float distance = 1f;
        private float _startY;
        private float _endY;
        private float _currentY;
        private bool _isGoingUp = true;

        private void Start()
        {
            _startY = transform.position.y;
            _endY = _startY + distance;
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                MovePingPongYAxis();
            }
        }

        private void MovePingPongYAxis()
        {
            if (_isGoingUp)
            {
                _currentY = Mathf.MoveTowards(transform.position.y, _endY, speed * Time.deltaTime);
                if (_currentY == _endY)
                {
                    _isGoingUp = false;
                }
            }
            else
            {
                _currentY = Mathf.MoveTowards(transform.position.y, _startY, speed * Time.deltaTime);
                if (_currentY == _startY)
                {
                    _isGoingUp = true;
                }
            }
            transform.position = new Vector3(transform.position.x, _currentY, transform.position.z);
        }
    }
}
