using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public class ImageBlink : MonoBehaviour
    {
        [Header("Blink Image")]
        [SerializeField] private Image blinkImage;
        public float blinkSpeed = 1f;
        public float blinkTime = 1f;
        public bool blinkOn = false;
        public float blinkOffTime = 20f;

        private float blinkTimer = 0f;
        private float blinkAlpha = 0f;
        private bool blinkFadeIn = true;

        void Start()
        {
            blinkImage = GetComponent<Image>();
            blinkImage.color = new Color(0f, 0f, 0f, 0f);
        }

        void Update()
        {
            if (blinkOn)
            {
                blinkTimer += Time.deltaTime;

                if (blinkTimer >= blinkTime)
                {
                    blinkTimer = 0f;
                    blinkFadeIn = !blinkFadeIn;
                }

                if (blinkFadeIn)
                {
                    blinkAlpha = Mathf.Lerp(0f, 1f, blinkTimer / blinkTime);
                }
                else
                {
                    blinkAlpha = Mathf.Lerp(1f, 0f, blinkTimer / blinkTime);
                }

                blinkImage.color = new Color(1f, 1f, 1f, blinkAlpha);
            }
        }

        public void BlinkOn()
        {
            blinkOn = true;
            Invoke("BlinkOff", blinkOffTime);
        }

        public void BlinkOff()
        {
            blinkOn = false;
            blinkImage.color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
