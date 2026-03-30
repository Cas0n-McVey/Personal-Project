using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button retryButton;
    public Button mainMenuButton;
    public Button leftButton;
    public Button rightButton;
    public Button pauseButton;
    public GameObject spawnManager;
    public GameObject player;
    public GameObject pauseMenuUI;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI pauseHighScoreText;
    public static int highScore;
    public static bool gameIsPaused = false;

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


        if (gameIsPaused == false && gameOverManager.gameOver == false)
        {
            Resume();
        }
        else
        {
            if (gameOverManager.gameOver == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseHighScoreText.text = "High Score: " + highScore;
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
        pauseButton.gameObject.SetActive(false);

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
