using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class Player2ControllerWithPreset : PlayerController
    {
        [SerializeField] private PlayerInfo m_PlayerInfo;
        [SerializeField] protected ActorTriggerHandler m_ActorTriggerHandler;
        [SerializeField] private Key interactionKey;
        private bool isOwner = false;

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
            if (m_PlayerInfo._isPlayer2 && isOwner == false)
            {
                OnOwnershipRequest();
                isOwner = true;
            }

            if (m_PlayerInfo._isPlayer2)
            {
                transform.Translate(Vector3.up * m_Preset._moveSpeed * Time.deltaTime, Space.World);
                photonView.RPC("UIButtonMoveUp", RpcTarget.All);
            }
        }

        public override void MoveDown()
        {
            if (m_PlayerInfo._isPlayer2)
            {
                transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
                photonView.RPC("UIButtonMoveDown", RpcTarget.All);
            }
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

        public override void OnUpKeyReleased()
        {
            if (m_PlayerInfo._isPlayer2)
            {
                photonView.RPC("ResetColorButtonUp", RpcTarget.All);
            }
        }

        public override void OnDownKeyReleased()
        {
            if (m_PlayerInfo._isPlayer2)
            {
                photonView.RPC("ResetColorButtonDown", RpcTarget.All);
            }
        }

        public void OnOwnershipRequest()
        {
            GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
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