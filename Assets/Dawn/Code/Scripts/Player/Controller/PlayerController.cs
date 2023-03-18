using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public abstract class PlayerController : MonoBehaviourPunCallbacks, IPlayerController
    {

        [SerializeField] protected PlayerControllerSettingsPreset m_Preset;
        public Image imageButtonUp;
        public Image imageButtonDown;
        public Color colorWhenPressed;

        protected virtual void Update()
        {
            Keyboard keyboard = Keyboard.current;

            if (PunGameManager.isPause)
            {
                return;
            }
            
            if (keyboard[m_Preset._upKey].isPressed)
            {
                MoveUp();
            }
            else if (keyboard[m_Preset._downKey].isPressed)
            {
                MoveDown();
            }

            if (keyboard[m_Preset._upKey].wasReleasedThisFrame)
            {
                OnUpKeyReleased();
            }
            else if (keyboard[m_Preset._downKey].wasReleasedThisFrame)
            {
                OnDownKeyReleased();
            }
        }

        public abstract void MoveUp();
        public abstract void MoveDown();
        public abstract void OnUpKeyReleased();
        public abstract void OnDownKeyReleased();
    }
}
