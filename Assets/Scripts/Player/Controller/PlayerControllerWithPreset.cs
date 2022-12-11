using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControllerWithPreset : PlayerController
{
    [PunRPC]
    public override void MoveUp()
    {
        photonView.RPC("Up", RpcTarget.All);
    }

    [PunRPC]
    public void Up()
    {
        transform.Translate(Vector3.up * m_Preset._moveSpeed * Time.deltaTime, Space.World);
    }

    [PunRPC]
    public override void MoveDown()
    {
        photonView.RPC("Down", RpcTarget.All);
    }

    [PunRPC]
    public void Down()
    {
        transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
    }
}
