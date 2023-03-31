using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace GameDev4.Dawn
{
    public class PunCheckConnection : MonoBehaviourPunCallbacks
    {
        public int PlayerCount;
        int MaxPlayersPerRoom = 2;

        [SerializeField] private GameObject _lostConnectionPanel;
        [SerializeField] private GameObject[] _GameObjectsToDisable;

        [Header("For testing purposes")]
        [SerializeField] private bool isTest = false;
        private PunGameManager _punGameManager;

        private bool isLostConnection = false;

        private void Start()
        {
            _punGameManager = GetComponent<PunGameManager>();
        }

        void Update()
        {
            if (isTest == false)
            {
                if (PhotonNetwork.CurrentRoom != null)
                {
                    PlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
                }
                
                if (PlayerCount != MaxPlayersPerRoom)
                {
                    foreach (GameObject go in _GameObjectsToDisable)
                    {
                        go.SetActive(false);
                    }
                    if (isLostConnection == false)
                    {
                        CheckConnection();
                        isLostConnection = true;
                    }
                }
            }
        }

        private void CheckConnection()
        {
            if (PhotonNetwork.IsConnected)
            {
                _lostConnectionPanel.SetActive(true);
                _punGameManager.PauseGame(true);
            }
        }

        public void OnClickLeaveRoom()
        {
            _punGameManager.PauseGame(false);
            PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 1f;
            Time.timeScale = 1f;
            if (PlayerCount == 1)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
            }
            Invoke("LeaveRoom", 0.5f);
        }

        void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {   
            PhotonNetwork.Disconnect();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            PhotonNetwork.LoadLevel("MenuScene");
        }
    }
}
