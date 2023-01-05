using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class ObstacleTypeComponent : MonoBehaviour
    {
        [SerializeField] protected ObstacleType m_ObstacleType;
        public ObstacleType Type
        {
            get
            {
                return m_ObstacleType;
            }
            set
            {
                m_ObstacleType = value;
            }
        }
    }
}