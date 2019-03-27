namespace Assets.Scripts
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;

        private int currentScore;

        [SerializeField]
        private TextMeshProUGUI currentScoreText;

        public GameObject GameOverPanel { get => this.gameOverPanel; set => this.gameOverPanel = value; }

        public TextMeshProUGUI CurrentScoreText { get => this.currentScoreText; set => this.currentScoreText = value; }

        public void GameOver()
        {
            // Show game over panel with menu
            this.GameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void ScoreIncrement()
        {
            this.currentScore += 1;
            this.CurrentScoreText.text = this.currentScore.ToString();
        }

        // Start is called before the first frame update
        private void Start()
        {
            this.currentScore = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            // Empty
        }
    }
}