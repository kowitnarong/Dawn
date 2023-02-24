using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class PunGameManager : MonoBehaviourPun
    {
        public static bool isPause = false;
        public bool sPause;

        public void PauseGame(bool pause)
        {
            isPause = pause;
        }

        private void Update() {
            sPause = isPause;
        }
    }
}
