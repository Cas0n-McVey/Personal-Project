using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button retryButton;
    public Button mainMenuButton;
    public Button leftButton;
    public Button rightButton;
    public GameObject spawnManager;
    public GameObject player;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finaleScore;
    public static int highScore;

    private GameOverManager gameOverManager;
    private PlayerController playerController;
    private float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverManager = GameObject.Find("Player").GetComponent<GameOverManager>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public void GameOver()
    {
        retryButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        finaleScore.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        finaleScore.text = "Final " + scoreText.text;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ((int)score).ToString();
        score += Time.deltaTime;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
