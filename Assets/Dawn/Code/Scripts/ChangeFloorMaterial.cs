using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class ChangeFloorMaterial : MonoBehaviour
    {
        public Material[] materials;
        private void OnTriggerStay(Collider other)
        {
            ZoneTypeComponent ztc = other.GetComponent<ZoneTypeComponent>();
            //Debug.Log("ZoneTypeComponent: " + ztc);
            if (other.gameObject.tag == "Zone")
            {
                if (ztc != null)
                {
                    switch (ztc.Type)
                    {
                        case ZoneType.summerZone:
                            GetComponent<Renderer>().sharedMaterial = materials[0];
                            break;
                        case ZoneType.rainZone:
                            GetComponent<Renderer>().sharedMaterial = materials[1];
                            break;
                        case ZoneType.winterZone:
                            GetComponent<Renderer>().sharedMaterial = materials[2];
                            break;
                    }
                }
            }
        }
    }
}
