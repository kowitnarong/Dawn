using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

namespace GameDev4.Dawn
{
    public class PunPlayerItem : MonoBehaviourPunCallbacks
    {
        public TextMeshProUGUI playerName;

        public Color highlightColor;
        public GameObject leftArrowButton;
        public GameObject rightArrowButton;
        public GameObject readyButton;
        public TextMeshProUGUI playerReady;


        ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

        Player player;

        private void Start()
        {

        }

        public void SetPlayerInfo(Player _player)
        {
            playerName.text = _player.NickName;
            player = _player;
            UpdatePlayerItem(player);
        }

        public void ApplyLocalChanges()
        {
            readyButton.SetActive(true);
            readyButton.GetComponent<Button>().interactable = true;
            playerProperties["Ready"] = false;
            player.SetCustomProperties(playerProperties);
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            if (player == targetPlayer)
            {
                UpdatePlayerItem(targetPlayer);
            }
        }

        public void OnClickReady()
        {
            readyButton.GetComponent<Button>().interactable = false;
            playerProperties["Ready"] = true;
            player.SetCustomProperties(playerProperties);
        }

        void UpdatePlayerItem(Player player)
        {
            if (player.CustomProperties.ContainsKey("Ready"))
            {
                if ((bool)player.CustomProperties["Ready"])
                {
                    playerReady.text = "Ready!";
                    playerName.color = highlightColor;
                    GameObject.Find("LobbyManager").GetComponent<PunLobbyManager>().playReadyCount++;
                }
                else
                {
                    playerReady.text = "Not Ready!";
                    playerName.color = Color.white;
                }
            }
            else
            {
                playerReady.text = "Not Ready!";
                playerName.color = Color.white;
            }
        }
    }
}