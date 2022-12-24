using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

namespace GameDev4.Dawn
{
    public class ChangeCharacter : MonoBehaviourPun
    {
        [SerializeField] private float slowMotionTimeScale;

        private float startTimeScale;
        private float startFixedDeltaTime;

        private bool isSlowMotion = false;

        public Key changeCharacterKey = Key.Space;

        void Start()
        {
            startTimeScale = Time.timeScale;
            startFixedDeltaTime = Time.fixedDeltaTime;
        }

        void Update()
        {
            Keyboard keyboard = Keyboard.current;

            if (keyboard[changeCharacterKey].isPressed && isSlowMotion == false)
            {
                //isSlowMotion = true;
                photonView.RPC("SetSlowMotionOn", RpcTarget.AllBuffered);
            }
            else if (keyboard[changeCharacterKey].wasReleasedThisFrame && isSlowMotion == true)
            {
                //isSlowMotion = false;
                photonView.RPC("SetSlowMotionOff", RpcTarget.AllBuffered);
            }

            if (PhotonNetwork.IsMasterClient)
            {
                if (isSlowMotion)
                {
                    StartSlowMotion();
                }
                else
                {
                    StopSlowMotion();
                }
            }
        }

        [PunRPC]
        private void SetSlowMotionOn()
        {
            isSlowMotion = true;
        }

        [PunRPC]
        private void SetSlowMotionOff()
        {
            isSlowMotion = false;
        }

        private void StartSlowMotion()
        {
            Time.timeScale = slowMotionTimeScale;
            Time.fixedDeltaTime = Time.timeScale * slowMotionTimeScale;
        }

        private void StopSlowMotion()
        {
            Time.timeScale = startTimeScale;
            Time.fixedDeltaTime = startFixedDeltaTime;
        }
    }
}