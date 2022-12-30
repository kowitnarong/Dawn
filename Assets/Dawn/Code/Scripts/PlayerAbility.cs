using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class PlayerAbility : MonoBehaviour
    {
        private ChangeCharacter changeCharacter;

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
                    m_material.color = Color.red;
                    break;
                case 2:
                    m_material.color = Color.blue;
                    break;
                case 3:
                    m_material.color = Color.gray;
                    break;
            }
        }
    }
}