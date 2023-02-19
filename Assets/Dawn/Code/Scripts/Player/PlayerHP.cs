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

        private void Start()
        {
            //PhotonNetwork.AutomaticallySyncScene = true;
            currentHP = maxHP;
            hpText.text = "HP: " + currentHP.ToString();
        }

        private void Update()
        {
            if (currentHP <= 0)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    photonView.RPC("ResetLevel", RpcTarget.AllViaServer);
                }
            }
        }

        [PunRPC]
        private void ResetLevel()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.DestroyAll();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
                photonView.RPC("UpdateHP", RpcTarget.All, currentHP);
            }
        }

        [PunRPC]
        public void UpdateHP(int newHP)
        {
            currentHP = newHP;
            hpText.text = "HP: " + currentHP.ToString();
        }
    }
}