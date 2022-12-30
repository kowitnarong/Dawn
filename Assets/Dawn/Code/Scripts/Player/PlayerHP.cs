using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

namespace GameDev4.Dawn
{
    public class PlayerHP : MonoBehaviourPun
{
    public int maxHP = 4;
    public int currentHP;

    private TextMeshProUGUI hpText;

    private void Start()
    {
        currentHP = maxHP;
        hpText = GetComponentInChildren<TextMeshProUGUI>();
        hpText.text = currentHP.ToString();
    }

    public void TakeDamage(int damage)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            currentHP -= damage;
            photonView.RPC("UpdateHP", RpcTarget.All, currentHP);
        }
    }

    [PunRPC]
    public void UpdateHP(int newHP)
    {
        currentHP = newHP;
        hpText.text = currentHP.ToString();
    }
}
}