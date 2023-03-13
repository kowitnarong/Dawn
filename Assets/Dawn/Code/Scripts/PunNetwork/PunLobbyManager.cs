using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

namespace GameDev4.Dawn
{
    public class PunLobbyManager : MonoBehaviourPunCallbacks
    {

        public TMP_InputField roomInputfield;
        public GameObject lobbyPanel;
        public GameObject roomPanel;
        public TextMeshProUGUI roomName;

        public PunRoomItem roomItemPrefab;
        List<PunRoomItem> roomItemsList = new List<PunRoomItem>();
        public Transform contentObject;

        public float timeBetweenUpdates = 1.5f;
        float nextUpdateTime;

        public List<PunPlayerItem> playerItemsList = new List<PunPlayerItem>();
        public PunPlayerItem playerItemPrefab;
        public Transform playerItemParent;

        public GameObject playButton;
        public int playReadyCount = 0;

        [SerializeField] private PlayerControllerSettingsPreset _player1;
        [SerializeField] private PlayerControllerSettingsPreset _player2;

        private int indexRoom = 1;

        //public bool isHost = false;

        private void Start()
        {
            PhotonNetwork.JoinLobby();
        }

        public void OnClickCreate()
        {
            /*if (string.IsNullOrEmpty(roomInputfield.text))
            {
                return;
            }*/
            PhotonNetwork.CreateRoom(PhotonNetwork.NickName, new RoomOptions { MaxPlayers = 2, BroadcastPropsChangeToAll = true });
            //isHost = true;
        }

        public override void OnJoinedRoom()
        {
            lobbyPanel.SetActive(false);
            roomPanel.SetActive(true);
            roomName.text = "Room: " + PhotonNetwork.CurrentRoom.Name + "'s";
            UpdatePlayerList();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (Time.time > nextUpdateTime)
            {
                UpdateRoomList(roomList);
                nextUpdateTime = Time.time + timeBetweenUpdates;
            }
        }

        void UpdateRoomList(List<RoomInfo> list)
        {
            indexRoom = 1;
            foreach (PunRoomItem item in roomItemsList)
            {
                Destroy(item.gameObject);
            }
            roomItemsList.Clear();

            foreach (RoomInfo room in list)
            {
                PunRoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
                newRoom.SetRoomName(indexRoom++, room.Name);
                newRoom.SetRoomPlayers(room.PlayerCount, room.MaxPlayers);
                roomItemsList.Add(newRoom);
            }
        }

        public void ClickUpdateRoomList()
        {
            PhotonNetwork.JoinLobby();
        }

        public void JoinRoom(string roomName)
        {
            PhotonNetwork.JoinRoom(roomName);
        }

        public void OnClickLeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
            //isHost = false;
            playReadyCount = 0;
        }

        public void Kick()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
                {
                    Kick(player.Value);
                }
            }
            else
            {
                OnClickLeaveRoom();
            }
        }

        private void Kick(Photon.Realtime.Player playerToKick)
        {
            PhotonNetwork.CloseConnection(playerToKick);
        }

        public override void OnLeftRoom()
        {
            lobbyPanel.SetActive(true);
            roomPanel.SetActive(false);
            playReadyCount = 0;
            //isHost = false;

            PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "Ready", false } });
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public void OnDisconnected()
        {
            PhotonNetwork.Disconnect();
        }

        void UpdatePlayerList()
        {
            foreach (PunPlayerItem item in playerItemsList)
            {
                Destroy(item.gameObject);
            }
            playerItemsList.Clear();

            if (PhotonNetwork.CurrentRoom == null)
            {
                return;
            }

            foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                PunPlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
                newPlayerItem.SetPlayerInfo(player.Value);

                if (player.Value == PhotonNetwork.LocalPlayer)
                {
                    newPlayerItem.ApplyLocalChanges();
                }

                playerItemsList.Add(newPlayerItem);
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            UpdatePlayerList();
            playReadyCount = 0;
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            UpdatePlayerList();
            playReadyCount = 0;
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1 && playReadyCount >= 2)
            {
                playButton.SetActive(true);
            }
            else
            {
                playButton.SetActive(false);
            }
        }

        public void OnClickStartGame()
        {
            PhotonNetwork.LoadLevel("Level 1");
        }
    }
}