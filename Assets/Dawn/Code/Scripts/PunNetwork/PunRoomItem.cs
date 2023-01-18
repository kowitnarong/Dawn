using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameDev4.Dawn
{
    public class PunRoomItem : MonoBehaviour
    {
        public TMP_Text roomName;
        private string roomNameString;
        public TMP_Text roomPlayers;

        PunLobbyManager manager;

        public void Start()
        {
            manager = FindObjectOfType<PunLobbyManager>();
        }

        public void SetRoomName(int roomNumber, string name)
        {
            roomName.text = roomNumber + ".  " + name + "'s Room";
            roomNameString = name;
        }

        public void SetRoomPlayers(int players, int maxPlayers)
        {
            //Debug.Log("SetRoomPlayers: " + players + "/" + maxPlayers);
            roomPlayers.text = players + "/" + maxPlayers;
        }

        public void OnClickJoinRoom()
        {
            manager.JoinRoom(roomNameString);
        }
    }
}