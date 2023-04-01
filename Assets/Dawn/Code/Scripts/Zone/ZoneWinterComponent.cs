using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class ZoneWinterComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] PlayerAbility _playerAbility;
        [SerializeField] private string currentAbility;
        [SerializeField] private GameObject slowIcon;

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
                        case ZoneType.winterZone:
                            CheckPlayerAbility();
                            if (currentAbility == "rain")
                            {
                                rb.drag = speedWhenDeduct;
                                slowIcon.SetActive(true);
                            }
                            else
                            {
                                rb.drag = defaultSpeed;
                                slowIcon.SetActive(false);
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