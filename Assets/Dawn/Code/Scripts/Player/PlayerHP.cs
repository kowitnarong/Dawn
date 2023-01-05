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

        private void Start()
        {
            currentHP = maxHP;
            hpText.text = "HP: " + currentHP.ToString();
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