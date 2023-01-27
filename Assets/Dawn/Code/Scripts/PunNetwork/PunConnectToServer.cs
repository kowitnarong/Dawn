using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;

namespace GameDev4.Dawn
{
    public class PunConnectToServer : MonoBehaviourPunCallbacks
    {
        public TMP_InputField usernameInput;
        public TextMeshProUGUI statusText;

        public void OnClickConnect()
        {
            if (string.IsNullOrEmpty(usernameInput.text))
            {
                return;
            }

            PhotonNetwork.NickName = usernameInput.text;
            statusText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
