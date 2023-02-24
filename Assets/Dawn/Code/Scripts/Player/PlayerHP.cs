using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

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
        [Header("Pause Game")]
        [SerializeField] private PunGameManager punGameManager;

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
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.DestroyAll();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            if (currentHP <= 0)
            {
                punGameManager.PauseGame(true);
                if (PhotonNetwork.IsMasterClient)
                {
                    gameOverUIMasterClient.SetActive(true);
                    photonView.RPC("ShowUIResetLevel", RpcTarget.Others);
                }
            }
        }
    }
}