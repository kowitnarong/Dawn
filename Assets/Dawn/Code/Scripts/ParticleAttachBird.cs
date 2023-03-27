using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class ParticleAttachBird : MonoBehaviour
    {
        public Transform parent;
        
        void FixedUpdate()
        {
            this.transform.position = parent.position;
        }
    }
}
