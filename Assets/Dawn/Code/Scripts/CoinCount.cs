using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace GameDev4.Dawn
{
    public class CoinCount : MonoBehaviourPun
    {
        public int currentCoin = 0;

        public event Action<int> onCoinCountChange;

        private void Start()
        {
            
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
            photonView.RPC("PlaySoundUseCoin", RpcTarget.All);
            photonView.RPC("UpdateCoinAll", RpcTarget.All, currentCoin);
        }

        [PunRPC]
        public void UpdateCoinAll(int newCoin)
        {
            currentCoin = newCoin;
            onCoinCountChange?.Invoke(currentCoin);
        }

        [PunRPC]
        private void PlaySoundCollectCoin()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_collectCoin");
        }

        [PunRPC]
        private void PlaySoundUseCoin()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_birdSwitched");
        }
    }
}
