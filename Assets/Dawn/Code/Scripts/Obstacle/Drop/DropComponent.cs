using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class DropComponent : MonoBehaviourPun, IInteractable, IActorEnterExitHandler
    {
        private PlayerHP playerHP;
        private PlayerAbility _playerAbility;
        private string currentAbility;
        protected bool isDestroyed = false;

        [Header("Setting (Less more faster)")]
        [SerializeField] private float defaultSpeed = 0.4f;
        [SerializeField] private float speedWhenDeduct = 2f;
        [SerializeField] private float timeResetSpeed = 2f;

        [Header("Destroy Time")]
        [SerializeField] private float destroyTime = 5f;

        private void Start()
        {
            playerHP = GameObject.FindGameObjectWithTag("Ball").GetComponent<PlayerHP>();
            _playerAbility = GameObject.FindGameObjectWithTag("Ball").GetComponent<PlayerAbility>();
            Invoke("DestroyObjectAfterSpawn", destroyTime);
        }

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
                    case ObstacleType.drop:
                        CheckPlayerAbility();
                        if (currentAbility == "summer" || currentAbility == "winter")
                        {
                            playerHP.TakeDamage(1);
                            if (PhotonNetwork.IsMasterClient)
                            {
                                photonView.RPC("PlaySoundHitBird", RpcTarget.All);
                            }
                            _playerAbility.SlowSpeed(speedWhenDeduct, defaultSpeed, timeResetSpeed);
                        }
                        else
                        {
                            if (PhotonNetwork.IsMasterClient)
                            {
                                photonView.RPC("PlaySoundDestroy", RpcTarget.All);
                            }
                        }
                        break;
                }
                isDestroyed = true;
            }

            DestroyObject();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                isDestroyed = true;
                DestroyObject();
            }
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void DestroyObjectAfterSpawn()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
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

        [PunRPC]
        private void PlaySoundHitBird()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_dropHitBird");
        }

        [PunRPC]
        private void PlaySoundDestroy()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_monsterDie");
        }
    }
}