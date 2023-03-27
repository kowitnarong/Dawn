using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class SunMonsterComponent : MonoBehaviourPun, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private PlayerHP playerHP;
        [SerializeField] private PlayerAbility _playerAbility;
        private string currentAbility;
        protected bool isDestroyed = false;

        [SerializeField] private int damage = 1;

        [Header("Particle")]
        [SerializeField] private GameObject transformParticle;
        [SerializeField] private GameObject particleMonsterDie;

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
                    case ObstacleType.sunMonster:
                        CheckPlayerAbility();
                        if (currentAbility == "rain" || currentAbility == "winter")
                        {
                            playerHP.TakeDamage(damage);
                        }
                        else
                        {
                            if (PhotonNetwork.IsMasterClient)
                            {
                                photonView.RPC("PlaySoundDestroy", RpcTarget.All);
                                photonView.RPC("SpawnParticleMonsterDie", RpcTarget.All);
                            }
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

        [PunRPC]
        private void SpawnParticleMonsterDie()
        {
            GameObject particle = Instantiate(particleMonsterDie, transformParticle.transform.position, Quaternion.identity);
            Destroy(particle, 1f);
        }

        [PunRPC]
        private void PlaySoundDestroy()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_monsterDie");
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