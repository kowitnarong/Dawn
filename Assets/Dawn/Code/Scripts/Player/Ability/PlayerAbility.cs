using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class PlayerAbility : MonoBehaviour
    {
        [Header("Current Ability")]
        public playerAbility m_playerAbility = playerAbility.summer;
        public enum playerAbility {summer, rain, winter} 

        private ChangeCharacter changeCharacter;
        [Header("Setting Preset")]
        [SerializeField] private PlayerAbilityPreset playerAbilitySummer;
        [SerializeField] private PlayerAbilityPreset playerAbilityRain;
        [SerializeField] private PlayerAbilityPreset playerAbilityWinter;


        private void Start()
        {
            changeCharacter = GetComponent<ChangeCharacter>();
        }

        private void Update()
        {
            UpdateAbility(changeCharacter.CharacterSelect);
        }

        private void UpdateAbility(int characterSelect)
        {
            Material m_material = GetComponent<Renderer>().material;
            switch (characterSelect)
            {
                case 1:
                    m_material.color = playerAbilitySummer.color;
                    m_playerAbility = playerAbility.summer;
                    break;
                case 2:
                    m_material.color = playerAbilityRain.color;
                    m_playerAbility = playerAbility.rain;
                    break;
                case 3:
                    m_material.color = playerAbilityWinter.color;
                    m_playerAbility = playerAbility.winter;
                    break;
            }
        }
    }
}