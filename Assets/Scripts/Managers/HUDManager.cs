using UnityEngine;
using UnityEngine.UI;
using Character;

namespace Managers
{
    public class HUDManager : MonoBehaviour
    {
        public Slider HealthSlider;
        public GameObject GameOverPanel;

        private CharHealth playerHealth;
        private bool isGameOver;

        private void Start()
        {
            playerHealth = GameManager.GetInstance().GetPlayerObject().GetComponent<CharHealth>();
            HealthSlider.maxValue = playerHealth.GetHealth();
            HealthSlider.value = HealthSlider.maxValue;
            isGameOver = false;
        }

        private void FixedUpdate()
        {
            if (isGameOver) return;

            var hp = playerHealth.GetHealth();
            HealthSlider.value = playerHealth.GetHealth();

            if (hp <= 0f)
            {
                isGameOver = true;
                GameOverPanel.SetActive(true);
            }
        }
    }
}