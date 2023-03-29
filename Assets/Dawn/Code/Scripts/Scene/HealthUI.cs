using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public class HealthUI : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private PlayerHP playerHP;
        [SerializeField] private int health;
        [SerializeField] private Image[] hearts;
        [SerializeField] private Sprite fullHeart;

        private void Start()
        {
            health = playerHP.maxHP;
            UpdateHealth(health);
            playerHP.onPlayerHPChange += UpdateHealth;
        }

        private void OnDestroy()
        {
            playerHP.onPlayerHPChange -= UpdateHealth;
        }

        private void UpdateHealth(int health)
        {
            this.health = health;

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }
}
