using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class ChangeCharacter : MonoBehaviourPun
    {
        [SerializeField] private float slowMotionTimeScale;
        [SerializeField] private PlayerInfo playerInfo;

        private float startTimeScale;
        private float startFixedDeltaTime;

        private bool isSlowMotion = false;

        public Key startCharacterKey = Key.Space;

        [Header("----------Player 1----------")]
        public Key player1ChangeCharacterKeyLeft = Key.A;
        public Key player1ChangeCharacterKeyRight = Key.D;

        [Header("----------Player 2----------")]
        public Key player2ChangeCharacterKeyLeft = Key.LeftArrow;
        public Key player2ChangeCharacterKeyRight = Key.RightArrow;

        [SerializeField] private float charecterSelect = 1;
        private float tempCharacterSelect = 1;

        [Header("----------Character UI----------")]
        [SerializeField] private GameObject characterChangeUI;
        [SerializeField] private Image[] characterImages;

        void Start()
        {
            startTimeScale = Time.timeScale;
            startFixedDeltaTime = Time.fixedDeltaTime;
            CharacterSelectAnimation();
        }

        void Update()
        {
            Keyboard keyboard = Keyboard.current;

            if (keyboard[startCharacterKey].isPressed && isSlowMotion == false)
            {
                photonView.RPC("SetSlowMotionOn", RpcTarget.AllBuffered);
            }
            else if (keyboard[startCharacterKey].wasReleasedThisFrame && isSlowMotion == true)
            {
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

            SelectCharacter(keyboard);
        }

        [PunRPC]
        private void SetSlowMotionOn()
        {
            isSlowMotion = true;
            characterChangeUI.SetActive(true);
        }

        [PunRPC]
        private void SetSlowMotionOff()
        {
            isSlowMotion = false;
            characterChangeUI.SetActive(false);
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

        public void CharacterSelectAnimation()
        {

            if (charecterSelect == 1)
            {
                characterImages[0].rectTransform.sizeDelta = new Vector2(200, 200);
            }
            else
            {
                characterImages[0].rectTransform.sizeDelta = new Vector2(100, 100);
            }

            if (charecterSelect == 2)
            {
                characterImages[1].rectTransform.sizeDelta = new Vector2(200, 200);
            }
            else
            {
                characterImages[1].rectTransform.sizeDelta = new Vector2(100, 100);
            }

            if (charecterSelect == 3)
            {
                characterImages[2].rectTransform.sizeDelta = new Vector2(200, 200);
            }
            else
            {
                characterImages[2].rectTransform.sizeDelta = new Vector2(100, 100);
            }
        }

        private void SelectCharacter(Keyboard keyboard)
        {
            if (isSlowMotion)
            {
                tempCharacterSelect = charecterSelect;
                if (playerInfo._isPlayer1 && keyboard[player1ChangeCharacterKeyLeft].wasPressedThisFrame)
                {
                    if (charecterSelect > 1)
                    {
                        tempCharacterSelect--;
                        photonView.RPC("UpdateCharacterSelect", RpcTarget.AllBuffered, tempCharacterSelect);
                    }
                }
                else if (playerInfo._isPlayer1 && keyboard[player1ChangeCharacterKeyRight].wasPressedThisFrame)
                {
                    if (charecterSelect < 3)
                    {
                        tempCharacterSelect++;
                        photonView.RPC("UpdateCharacterSelect", RpcTarget.AllBuffered, tempCharacterSelect);
                    }
                }
                else if (playerInfo._isPlayer2 && keyboard[player2ChangeCharacterKeyLeft].wasPressedThisFrame)
                {
                    if (charecterSelect > 1)
                    {
                        tempCharacterSelect--;
                        photonView.RPC("UpdateCharacterSelect", RpcTarget.AllBuffered, tempCharacterSelect);
                    }
                }
                else if (playerInfo._isPlayer2 && keyboard[player2ChangeCharacterKeyRight].wasPressedThisFrame)
                {
                    if (charecterSelect < 3)
                    {
                        tempCharacterSelect++;
                        photonView.RPC("UpdateCharacterSelect", RpcTarget.AllBuffered, tempCharacterSelect);
                    }
                }
            }
        }

        [PunRPC]
        private void UpdateCharacterSelect(float tempCharacterSelect)
        {
            charecterSelect = tempCharacterSelect;
            CharacterSelectAnimation();
        }
    }
}