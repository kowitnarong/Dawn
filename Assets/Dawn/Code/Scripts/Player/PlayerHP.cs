using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using System;

namespace GameDev4.Dawn
{
    public class PlayerHP : MonoBehaviourPun
    {
        public int maxHP = 4;
        public int currentHP;

        //[SerializeField] private TextMeshProUGUI hpText;

        [Header("Game Over UI")]
        [SerializeField] private GameObject gameOverUIMasterClient;
        [SerializeField] private GameObject gameOverUIOtherClient;
        [Header("Game Over")]
        [SerializeField] private PunGameManager punGameManager;
        [SerializeField] private PunGameTimer punGameTimer;
        [Header("Scene Manager")]
        [SerializeField] private GameAppFlowManager gameAppFlowManager;
        [SerializeField] private Animator transition;
        [Header("Particle")]
        [SerializeField] private PlayerAbility playerAbility;
        [SerializeField] private ParticleSystem particleBirdHeal;
        [SerializeField] private ParticleSystem particleBirdHurtSummer;
        [SerializeField] private ParticleSystem particleBirdHurtRain;
        [SerializeField] private ParticleSystem particleBirdHurtWinter;

        [HideInInspector] public bool isGameOver = false;

        public event Action<int> onPlayerHPChange;

        private void Start()
        {
            currentHP = maxHP;
            //hpText.text = "HP: " + currentHP.ToString();
        }

        [PunRPC]
        private void ShowUIResetLevel()
        {
            gameOverUIOtherClient.SetActive(true);
        }

        [PunRPC]
        private void ResetLevel()
        {
            PunGameManager.isPause = false;
            PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 1f;
            Time.timeScale = 1f;
            gameAppFlowManager.ResetSceneWithTransition(transition);
        }

        public void ClickResetLevel()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC("ResetLevel", RpcTarget.AllViaServer);
            }
        }

        public void Heal(int heal)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC("PlaySoundBirdHeal", RpcTarget.All);
                photonView.RPC("PlayParticleHeal", RpcTarget.All);
                if (currentHP >= maxHP)
                {
                    return;
                }
                currentHP += heal;
                photonView.RPC("UpdateHP", RpcTarget.All, currentHP);
            }
        }

        public void TakeDamage(int damage)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                currentHP -= damage;
                if (currentHP < 0)
                {
                    currentHP = 0;
                }
                if (isGameOver == false)
                {
                    photonView.RPC("PlaySoundBirdHurt", RpcTarget.All);
                    if (playerAbility.m_playerAbility == PlayerAbility.playerAbility.summer)
                    {
                        photonView.RPC("PlayParticleHurtSummer", RpcTarget.All);
                    }
                    else if (playerAbility.m_playerAbility == PlayerAbility.playerAbility.rain)
                    {
                        photonView.RPC("PlayParticleHurtRain", RpcTarget.All);
                    }
                    else if (playerAbility.m_playerAbility == PlayerAbility.playerAbility.winter)
                    {
                        photonView.RPC("PlayParticleHurtWinter", RpcTarget.All);
                    }
                    photonView.RPC("UpdateHP", RpcTarget.All, currentHP);
                }
            }
        }

        [PunRPC]
        public void UpdateHP(int newHP)
        {
            currentHP = newHP;
            //hpText.text = "HP: " + currentHP.ToString();
            onPlayerHPChange?.Invoke(currentHP);
            if (currentHP <= 0 && isGameOver == false)
            {
                punGameManager.PauseGame(true);
                isGameOver = true;
                if (PhotonNetwork.IsMasterClient)
                {
                    photonView.RPC("PlaySoundBirdDie", RpcTarget.All);
                    gameOverUIMasterClient.SetActive(true);
                    punGameTimer.StopTimer();
                    photonView.RPC("ShowUIResetLevel", RpcTarget.Others);
                }
            }
        }

        [PunRPC]
        public void PlaySoundBirdHurt()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_birdHurt");
        }

        [PunRPC]
        public void PlaySoundBirdHeal()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_collectHealItem");
        }

        [PunRPC]
        public void PlayParticleHeal()
        {
            particleBirdHeal.Play();
        }

        [PunRPC]
        public void PlayParticleHurtSummer()
        {
            particleBirdHurtSummer.Play();
        }

        [PunRPC]
        public void PlayParticleHurtRain()
        {
            particleBirdHurtRain.Play();
        }

        [PunRPC]
        public void PlayParticleHurtWinter()
        {
            particleBirdHurtWinter.Play();
        }

        [PunRPC]
        public void PlaySoundBirdDie()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_GameOver");
        }
    }
}