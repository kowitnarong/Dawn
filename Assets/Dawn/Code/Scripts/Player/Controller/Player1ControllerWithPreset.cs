using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

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
            }
        }

        public override void MoveDown()
        {
            if (m_PlayerInfo._isPlayer1)
            {
                transform.Translate(Vector3.down * m_Preset._moveSpeed * Time.deltaTime, Space.World);
            }
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