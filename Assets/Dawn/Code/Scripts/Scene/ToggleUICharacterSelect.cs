using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameDev4.Dawn
{
    public class ToggleUICharacterSelect : MonoBehaviour
    {
        public List<Toggle> toggles;
        public Button connectButton;
        public TMP_InputField characterName;

        public static int index = 0;
        [SerializeField] protected bool isSelected = true;


        public void Start()
        {
            toggles[0].isOn = true;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
        }

        private void Update()
        {
            if (toggles[0].isOn == false && toggles[1].isOn == false && toggles[2].isOn == false)
            {
                isSelected = false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(characterName.text))
                {
                    isSelected = false;
                }
                else
                {
                    isSelected = true;
                }
            }
            OnConnectEnable();
        }

        public void CharacterSummerSelected()
        {
            if (toggles[0].isOn == true)
            {
                toggles[0].isOn = true;
                toggles[1].isOn = false;
                toggles[2].isOn = false;
                index = 0;
            }
        }

        public void CharacterRainSelected()
        {
            if (toggles[1].isOn == true)
            {
                toggles[0].isOn = false;
                toggles[1].isOn = true;
                toggles[2].isOn = false;
                index = 1;
            }
        }

        public void CharacterWinterSelected()
        {
            if (toggles[2].isOn == true)
            {
                toggles[0].isOn = false;
                toggles[1].isOn = false;
                toggles[2].isOn = true;
                index = 2;
            }
        }

        private void OnConnectEnable()
        {
            if (isSelected == true)
            {
                connectButton.interactable = true;
            }
            else
            {
                connectButton.interactable = false;
            }
        }
    }
}
