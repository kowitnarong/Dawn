using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public class Player1ControllerWithPreset : PlayerController
    {
        [SerializeField] private PlayerInfo m_PlayerInfo;
        [SerializeField] protected ActorTriggerHandler m_ActorTriggerHandler;
        [SerializeField] private Key interactionKey;

        private void Awake()
        {
            m_PlayerInfo = GameObject.Find("--PunNetworkManager--").GetComponent<PlayerInfo>();
        }

        protected override void Update()
        {
            base.Update();

            Keyboard keyboard = Keyboard.current;

            if (keyboard[interactionKey].wasPressedThisFrame)
            {
                PerformInteraction();
            }
        }

        public override void MoveUp()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                transform.Translate(Vector3.up * m_Preset._moveSpeed * Time.deltaTime, Space.World);
                photonView.RPC("UIButtonMoveUp", RpcTarget.All);
            }
        }

        public override void MoveDown()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
                photonView.RPC("UIButtonMoveDown", RpcTarget.All);
            }
        }

        public override void OnUpKeyReleased()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                photonView.RPC("ResetColorButtonUp", RpcTarget.All);
            }
        }

        public override void OnDownKeyReleased()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                photonView.RPC("ResetColorButtonDown", RpcTarget.All);
            }
        }

        public void EnableCanMove()
        {
            isCanMove = true;
        }

        [PunRPC]
        public void UIButtonMoveUp()
        {
            imageButtonUp.color = colorWhenPressed;
        }

        [PunRPC]
        public void UIButtonMoveDown()
        {
            imageButtonDown.color = colorWhenPressed;
        }

        [PunRPC]
        public void ResetColorButtonUp()
        {
            imageButtonUp.color = Color.white;
        }

        [PunRPC]
        public void ResetColorButtonDown()
        {
            imageButtonDown.color = Color.white;
        }

        protected virtual void PerformInteraction()
        {
            var interactable = m_ActorTriggerHandler.GetInteractable();

            if (interactable != null)
            {
                interactable.Interact(gameObject);
            }
        }
    }
}