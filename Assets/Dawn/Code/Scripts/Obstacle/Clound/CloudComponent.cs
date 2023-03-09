using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class CloudComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private PlayerHP playerHP;
        [SerializeField] private PlayerAbility _playerAbility;
        private string currentAbility;
        protected bool isDestroyed = false;

        [SerializeField] private int damage = 1;

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
                    case ObstacleType.cloud:
                        CheckPlayerAbility();
                        if (currentAbility == "summer" || currentAbility == "winter")
                        {
                            playerHP.TakeDamage(damage);
                        }
                        break;
                }
                isDestroyed = true;
            }

            DestroyObject();
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void DestroyObject()
        {
            if (PhotonNetwork.IsMasterClient && isDestroyed)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
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