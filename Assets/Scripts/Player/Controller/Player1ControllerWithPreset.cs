using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
            photonView.RPC("Up", RpcTarget.OthersBuffered);
        }
    }

    [PunRPC]
    public void Up()
    {
        transform.Translate(Vector3.up * m_Preset._moveSpeed * Time.deltaTime, Space.World);
    }

    public override void MoveDown()
    {
        if (m_PlayerInfo._isPlayer1)
        {
            transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
            photonView.RPC("Down", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void Down()
    {
        transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
    }
}
