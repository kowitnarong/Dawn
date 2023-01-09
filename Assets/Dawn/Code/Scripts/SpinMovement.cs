using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class SpinMovement : MonoBehaviour
    {
        [SerializeField]
        private float m_AngularSpeed = 5.0f;
        [SerializeField]
        private Vector3 m_AxisOfRotation = new Vector3(1.0f, 0, 0);

        Transform m_ObjTransform;

        // Start is called before the first frame update
        void Start()
        {
            m_ObjTransform = gameObject.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            m_ObjTransform.Rotate(m_AxisOfRotation, m_AngularSpeed);
        }
    }
}