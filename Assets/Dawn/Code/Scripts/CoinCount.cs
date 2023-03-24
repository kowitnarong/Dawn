using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace GameDev4.Dawn
{
    public class CoinCount : MonoBehaviourPun
    {
        public int currentCoin = 0;
        [SerializeField] private TextMeshProUGUI coinText;

        private void Start()
        {
            coinText.text = "Coin: " + currentCoin.ToString();
        }

        public void AddCoin(int coin)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                currentCoin += coin;
                photonView.RPC("PlaySoundCollectCoin", RpcTarget.All);
                photonView.RPC("UpdateCoinAll", RpcTarget.All, currentCoin);
            }
        }

        public void UseCoin(int coin)
        {
            currentCoin -= coin;
            photonView.RPC("UpdateCoinAll", RpcTarget.All, currentCoin);
        }

        [PunRPC]
        public void UpdateCoinAll(int newCoin)
        {
            currentCoin = newCoin;
            coinText.text = "Coin: " + currentCoin.ToString();
        }

        [PunRPC]
        private void PlaySoundCollectCoin()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_collectCoin");
        }
    }
}
