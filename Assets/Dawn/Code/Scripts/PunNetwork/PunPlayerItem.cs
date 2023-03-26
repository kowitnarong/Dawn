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

        //public Color highlightColor;
        public GameObject leftArrowButton;
        public GameObject rightArrowButton;
        public GameObject readyButton;
        public GameObject kickButton;
        public TextMeshProUGUI playerReady;

        public Image playerBGImage;

        public Sprite playerReadyImage;
        public Sprite playerNotReadyImage;

        public Image playerAvatar;
        public Sprite[] avatars;
        private int indexAvatar;

        public Image borderImage;
        public GameObject player1UI;
        public GameObject player2UI;
        public GameObject CrownUI;

        ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();

        Player player;

        private void Start()
        {
            indexAvatar = ToggleUICharacterSelect.index;
            playerProperties["playerAvatar"] = indexAvatar;
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        }

        public void SetPlayerInfo(Player _player, int actorNumber)
        {
            playerName.text = _player.NickName;
            player = _player;
            if (actorNumber == 1)
            {
                borderImage.color = Color.red;
                player1UI.SetActive(true);
                CrownUI.SetActive(true);
            }
            else if (actorNumber >= 2)
            {
                borderImage.color = Color.blue;
                player2UI.SetActive(true);
            }
            
            UpdatePlayerItem(player);
        }

        public void ApplyLocalChanges()
        {
            readyButton.SetActive(true);
            readyButton.GetComponent<Button>().interactable = true;
            playerProperties["Ready"] = false;
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
            Debug.Log("Player is ready");
            player.SetCustomProperties(playerProperties);
        }

        void UpdatePlayerItem(Player player)
        {
            if (player.CustomProperties.ContainsKey("playerAvatar"))
            {
                //Debug.Log((int)player.CustomProperties["playerAvatar"]);
                playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
                playerAvatar.color = new Color(255, 255, 255, 255);
                playerProperties["playerAvatar"] = player.CustomProperties["playerAvatar"];
            }

            if (player.CustomProperties.ContainsKey("Ready"))
            {
                if ((bool)player.CustomProperties["Ready"])
                {
                    playerBGImage.sprite = playerReadyImage;
                    readyButton.SetActive(false);
                    GameObject.Find("LobbyManager").GetComponent<PunLobbyManager>().playReadyCount++;
                }
                else
                {
                    playerBGImage.sprite = playerNotReadyImage;
                }
            }
            else
            {
                playerBGImage.sprite = playerNotReadyImage;
            }
        }

        /*private void Start()
        {
            indexAvatar = ToggleUICharacterSelect.index;
            playerProperties["playerAvatar"] = indexAvatar;
            playerProperties["isKick"] = isKick;
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
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
            Debug.Log("Player is ready");
            player.SetCustomProperties(playerProperties);
        }

        public void OnKick()
        {
            string nickname = playerName.text;
            Kick(nickname);
        }*/

        /*void UpdatePlayerItem(Player player)
        {
            if (player.CustomProperties.ContainsKey("playerAvatar"))
            {
                //Debug.Log((int)player.CustomProperties["playerAvatar"]);
                playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
                playerAvatar.color = new Color(255, 255, 255, 255);
                playerProperties["playerAvatar"] = player.CustomProperties["playerAvatar"];
            }
            if (player.CustomProperties.ContainsKey("isKick"))
            {
                if ((bool)player.CustomProperties["isKick"])
                {
                    if (GameObject.Find("LobbyManager").GetComponent<PunLobbyManager>().isHost)
                    {
                        if (readyButton.activeSelf == false)
                        { kickButton.SetActive(true); }
                    }
                }
            }

            if (player.CustomProperties.ContainsKey("Ready"))
            {
                if ((bool)player.CustomProperties["Ready"])
                {

                    playerBGImage.sprite = playerReadyImage;
                    readyButton.SetActive(false);
                    GameObject.Find("LobbyManager").GetComponent<PunLobbyManager>().playReadyCount++;
                }
                else
                {
                    if (GameObject.Find("LobbyManager").GetComponent<PunLobbyManager>().isHost)
                    {
                        playerProperties["isKick"] = false;
                    }
                    else
                    {
                        playerProperties["isKick"] = true;
                        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
                    }
                    playerBGImage.sprite = playerNotReadyImage;
                }
            }
            else
            {
                if (GameObject.Find("LobbyManager").GetComponent<PunLobbyManager>().isHost)
                {
                    playerProperties["isKick"] = false;
                }
                else
                {
                    playerProperties["isKick"] = true;
                    PhotonNetwork.SetPlayerCustomProperties(playerProperties);
                }
                playerBGImage.sprite = playerNotReadyImage;
            }
        }*/
    }
}