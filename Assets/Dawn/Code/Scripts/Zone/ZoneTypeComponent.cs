using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class ZoneTypeComponent : MonoBehaviour
    {
        [SerializeField] protected ZoneType m_ZoneType;
        public ZoneType Type
        {
            get
            {
                return m_ZoneType;
            }
            set
            {
                m_ZoneType = value;
            }
        }
    }
}
