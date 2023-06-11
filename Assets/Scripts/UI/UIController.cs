using Ship;
using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshPro scoreText;
        [SerializeField] private TextMeshPro laserAmmoText;
        [SerializeField] private GameOverUI gameOverUI;
        private int _score = 0;
        private int _ammoCount = 0;

        private void Start()
        {
            Health.OnEnemyDestroyed += UpdateScore;
            LaserWeapon.OnLaserAmmoChanged += UpdateAmmo;
            SpaceshipHealth.OnPlayerDestroyed += GameOver;

            gameOverUI.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                UpdateScore(1);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                _ammoCount++;
                UpdateAmmo(_ammoCount);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _ammoCount--;
                UpdateAmmo(_ammoCount);
            }
        }


        public void UpdateScore(int amount)
        {
            _score += amount;
            UpdateScoreText();
        }

        public void UpdateAmmo(int newAmmoCount)
        {
            _ammoCount = newAmmoCount;
            UpdateAmmoText();
        }

        public void GameOver()
        {
            gameOverUI.gameObject.SetActive(true);
            gameOverUI.SetScoreOnGameOverScreen(_score);
        }

        private void UpdateScoreText()
        {
            scoreText.text = _score.ToString();
        }

        private void UpdateAmmoText()
        {
            laserAmmoText.text = GenerateAmmoLoadString(_ammoCount);
        }

        private string GenerateAmmoLoadString(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += "|";
            }

            return result;
        }
    }
}