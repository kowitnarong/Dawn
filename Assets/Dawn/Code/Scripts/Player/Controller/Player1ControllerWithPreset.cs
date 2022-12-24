using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class Player1ControllerWithPreset : PlayerController
    {
        [SerializeField] private PlayerInfo m_PlayerInfo;

        private void Awake()
        {
            m_PlayerInfo = GameObject.Find("--PunNetworkManager--").GetComponent<PlayerInfo>();
        }

        public override void MoveUp()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                transform.Translate(Vector3.up * m_Preset._moveSpeed * Time.deltaTime, Space.World);
            }
        }

        public override void MoveDown()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}