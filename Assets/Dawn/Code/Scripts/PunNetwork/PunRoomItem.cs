using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PunRoomItem : MonoBehaviour
{
    public TMP_Text roomName;
    PunLobbyManager manager;

    public void Start(){
        manager = FindObjectOfType<PunLobbyManager>();
    }

    public void SetRoomName(string name)
    {
        roomName.text = name;
    }

    public void OnClickJoinRoom()
    {
        manager.JoinRoom(roomName.text);
    }
}
