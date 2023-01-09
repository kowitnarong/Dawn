using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class Ping : MonoBehaviour
    {
        public TextMeshProUGUI pingText;

        void Update()
        {
            pingText.text = "Ping :" + PhotonNetwork.GetPing();
        }
    }
}