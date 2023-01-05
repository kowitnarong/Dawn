using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class PlayerAbility : MonoBehaviour
    {
        private ChangeCharacter changeCharacter;
        [SerializeField] private PlayerAbilityPreset playerAbilityFire;
        [SerializeField] private PlayerAbilityPreset playerAbilityWater;
        [SerializeField] private PlayerAbilityPreset playerAbilityCold;

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
                    m_material.color = playerAbilityFire.color;
                    break;
                case 2:
                    m_material.color = playerAbilityWater.color;
                    break;
                case 3:
                    m_material.color = playerAbilityCold.color;
                    break;
            }
        }
    }
}