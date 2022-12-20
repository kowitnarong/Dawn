using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInfo : MonoBehaviour
{
    [Header("Player Info")]
    public bool _isPlayer1;
    public bool _isPlayer2;

    private void Start() {
        if(PhotonNetwork.IsMasterClient){
            _isPlayer1 = true;
        } else {
            _isPlayer2 = true;
        }
    }
}
