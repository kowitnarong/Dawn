using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public class CharacterUI : MonoBehaviour
    {
        [SerializeField] private ChangeCharacter changeCharacter;

        [SerializeField] private Image[] characterUI;

        private void Start()
        {
            changeCharacter.onCharacterChange += CharacterSelectImage;
        }

        private void OnEnable()
        {
            InitCharacterUI();
        }

        private void OnDisable()
        {

        }

        private void OnDestroy()
        {
            changeCharacter.onCharacterChange -= CharacterSelectImage;
        }

        private void InitCharacterUI()
        {
           switch (changeCharacter.CharacterSelect)
            {
                case 1:
                    characterUI[0].canvasRenderer.SetAlpha(1f);
                    characterUI[1].canvasRenderer.SetAlpha(0.5f);
                    characterUI[2].canvasRenderer.SetAlpha(0.5f);
                    break;
                case 2:
                    characterUI[0].canvasRenderer.SetAlpha(0.5f);
                    characterUI[1].canvasRenderer.SetAlpha(1f);
                    characterUI[2].canvasRenderer.SetAlpha(0.5f);
                    break;
                case 3:
                    characterUI[0].canvasRenderer.SetAlpha(0.5f);
                    characterUI[1].canvasRenderer.SetAlpha(0.5f);
                    characterUI[2].canvasRenderer.SetAlpha(1f);
                    break;
            }
        }

        private void CharacterSelectImage(int characterSelect)
        {
            switch (characterSelect)
            {
                case 1:
                    characterUI[0].canvasRenderer.SetAlpha(1f);
                    characterUI[1].canvasRenderer.SetAlpha(0.5f);
                    characterUI[2].canvasRenderer.SetAlpha(0.5f);
                    break;
                case 2:
                    characterUI[0].canvasRenderer.SetAlpha(0.5f);
                    characterUI[1].canvasRenderer.SetAlpha(1f);
                    characterUI[2].canvasRenderer.SetAlpha(0.5f);
                    break;
                case 3:
                    characterUI[0].canvasRenderer.SetAlpha(0.5f);
                    characterUI[1].canvasRenderer.SetAlpha(0.5f);
                    characterUI[2].canvasRenderer.SetAlpha(1f);
                    break;
            }
        }
    }
}
