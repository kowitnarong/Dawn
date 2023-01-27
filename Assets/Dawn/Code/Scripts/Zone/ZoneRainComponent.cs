using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class ZoneRainComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] PlayerAbility _playerAbility;
        [SerializeField] private string currentAbility;

        [Header("Setting (Less more faster)")]
        [SerializeField] private float defaultSpeed = 0.2f;
        [SerializeField] private float speedWhenDeduct = 5f;

        private void Start()
        {

        }

        public void Interact(GameObject actor)
        {

        }

        public void ActorEnter(GameObject actor)
        {

        }

        private void OnTriggerStay(Collider other)
        {
            ZoneTypeComponent ztc = GetComponent<ZoneTypeComponent>();
            if (other.gameObject.tag == "Interaction Trigger")
            {

                if (ztc != null)
                {
                    switch (ztc.Type)
                    {
                        case ZoneType.rainZone:
                            CheckPlayerAbility();
                            if (currentAbility == "summer")
                            {
                                rb.drag = speedWhenDeduct;
                            }
                            else
                            {
                                rb.drag = defaultSpeed;
                            }
                            break;
                    }
                }
            }
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void CheckPlayerAbility()
        {
            switch (_playerAbility.m_playerAbility)
            {
                case PlayerAbility.playerAbility.summer:
                    currentAbility = "summer";
                    break;
                case PlayerAbility.playerAbility.rain:
                    currentAbility = "rain";
                    break;
                case PlayerAbility.playerAbility.winter:
                    currentAbility = "winter";
                    break;
            }
        }
    }
}