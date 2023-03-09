using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace GameDev4.Dawn
{
    public class PlayerHP : MonoBehaviourPun
    {
        public int maxHP = 4;
        public int currentHP;

        [SerializeField] private TextMeshProUGUI hpText;

        [Header("Game Over UI")]
        [SerializeField] private GameObject gameOverUIMasterClient;
        [SerializeField] private GameObject gameOverUIOtherClient;
        [Header("Game Over")]
        [SerializeField] private PunGameManager punGameManager;
        [SerializeField] private PunGameTimer punGameTimer;
        [Header("Scene Manager")]
        [SerializeField] private GameAppFlowManager gameAppFlowManager;
        [SerializeField] private Animator transition;

        protected bool isGameOver = false;

        private void Start()
        {
            //PhotonNetwork.AutomaticallySyncScene = true;
            currentHP = maxHP;
            hpText.text = "HP: " + currentHP.ToString();
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
                photonView.RPC("UpdateHP", RpcTarget.All, currentHP);
            }
        }

        [PunRPC]
        public void UpdateHP(int newHP)
        {
            currentHP = newHP;
            hpText.text = "HP: " + currentHP.ToString();
            if (currentHP <= 0 && isGameOver == false)
            {
                punGameManager.PauseGame(true);
                isGameOver = true;
                if (PhotonNetwork.IsMasterClient)
                {
                    gameOverUIMasterClient.SetActive(true);
                    punGameTimer.StopTimer();
                    photonView.RPC("ShowUIResetLevel", RpcTarget.Others);
                }
            }
        }
    }
}