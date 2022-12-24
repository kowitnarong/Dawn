using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class Player2ControllerWithPreset : PlayerController
    {
        [SerializeField] private PlayerInfo m_PlayerInfo;
        private bool isOwner = false;

        private void Awake()
        {
            m_PlayerInfo = GameObject.Find("--PunNetworkManager--").GetComponent<PlayerInfo>();
        }

        private void Start()
        {

        }

        public override void MoveUp()
        {
            if (m_PlayerInfo._isPlayer2 && isOwner == false)
            {
                OnOwnershipRequest();
                isOwner = true;
            }

            if (m_PlayerInfo._isPlayer2)
            {
                transform.Translate(Vector3.up * m_Preset._moveSpeed * Time.deltaTime, Space.World);
            }
        }

        public override void MoveDown()
        {
            if (m_PlayerInfo._isPlayer2)
            {
                transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
            }
        }

        public void OnOwnershipRequest()
        {
            GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }
}