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
        public enum playerAbility { summer, rain, winter }

        [SerializeField] private GameObject textureObject;
        private Renderer m_material;
        private MeshFilter m_meshFilter;

        private ChangeCharacter changeCharacter;
        [Header("Setting Preset")]
        [SerializeField] private PlayerAbilityPreset playerAbilitySummer;
        [SerializeField] private PlayerAbilityPreset playerAbilityRain;
        [SerializeField] private PlayerAbilityPreset playerAbilityWinter;


        private void Start()
        {
            m_material = textureObject.GetComponent<Renderer>();
            m_meshFilter = textureObject.GetComponent<MeshFilter>();
            changeCharacter = GetComponent<ChangeCharacter>();
        }

        private void Update()
        {
            UpdateAbility(changeCharacter.CharacterSelect);
        }

        private void UpdateAbility(int characterSelect)
        {
            switch (characterSelect)
            {
                case 1:
                    m_meshFilter.mesh = playerAbilitySummer.mesh;
                    m_material.sharedMaterial = playerAbilitySummer.material;
                    m_playerAbility = playerAbility.summer;
                    break;
                case 2:
                    m_meshFilter.mesh = playerAbilityRain.mesh;
                    m_material.sharedMaterial = playerAbilityRain.material;
                    m_playerAbility = playerAbility.rain;
                    break;
                case 3:
                    m_meshFilter.mesh = playerAbilityWinter.mesh;
                    m_material.sharedMaterial = playerAbilityWinter.material;
                    m_playerAbility = playerAbility.winter;
                    break;
            }
        }
    }
}