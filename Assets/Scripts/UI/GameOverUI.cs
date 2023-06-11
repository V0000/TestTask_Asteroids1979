using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro scoreText;

        public void SetScoreOnGameOverScreen(int score)
        {
            scoreText.text = "SCORE: " + score.ToString();
        }

        public void RestartGame()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}