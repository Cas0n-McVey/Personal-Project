using TMPro;
using Unity.VisualScripting;
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
    public TextMeshProUGUI finalScoreText;
    public static int highScore;
    public TextMeshProUGUI highScoreText;

    private float score;
    private GameOverManager gameOverManager;
    private PlayerController playerController;
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
        finalScoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);

        scoreText.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);

        if(score > highScore)
        {
            highScore = (int)score;
            ManuManager.SavePlayer();
        }

        finalScoreText.text = "Final " + scoreText.text;
        highScoreText.text = "High Score: " + highScore;
    }

    /// <summary>
    /// Update the score for replayability
    /// </summary>
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ((int)score).ToString();
        score += Time.deltaTime;
    }

    /// <summary>
    /// Restarts the scene
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Goes back the Main Menu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
