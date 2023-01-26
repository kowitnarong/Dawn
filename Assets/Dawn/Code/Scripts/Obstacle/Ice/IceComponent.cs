using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class IceComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private PlayerHP playerHP;
        [SerializeField] private PlayerAbility _playerAbility;
        private string currentAbility;
        protected bool isDestroyed = false;

        public void Interact(GameObject actor)
        {

        }

        public void ActorEnter(GameObject actor)
        {
            ObstacleTypeComponent otc = GetComponent<ObstacleTypeComponent>();
            if (otc != null)
            {
                switch (otc.Type)
                {
                    case ObstacleType.ice:
                        CheckPlayerAbility();
                        if (currentAbility == "summer" || currentAbility == "rain")
                        {
                            playerHP.TakeDamage(1);
                        }
                        isDestroyed = true;
                        break;
                }
            }

            DestroyObject();
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void DestroyObject()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (isDestroyed)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
            }
        }

        public void CheckPlayerAbility()
        {
            if (_playerAbility.m_playerAbility == PlayerAbility.playerAbility.summer)
            {
                currentAbility = "summer";
            }
            else if (_playerAbility.m_playerAbility == PlayerAbility.playerAbility.rain)
            {
                currentAbility = "rain";
            }
            else if (_playerAbility.m_playerAbility == PlayerAbility.playerAbility.winter)
            {
                currentAbility = "winter";
            }
        }
    }
}