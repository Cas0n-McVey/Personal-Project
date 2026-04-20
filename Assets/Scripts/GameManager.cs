using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public Button resumeButton;
    public Button mainMenuButton2;
    public Image image;
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
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
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
            if (gameIsPaused == true && gameOverManager.gameOver == false)
            {
                Pause();
            }
        }
    }

    public void HandlePause()
    {
        gameIsPaused = !gameIsPaused;
        if(gameIsPaused && gameOverManager.gameOver == false)
        {
            Pause();
        }
        else if (gameIsPaused == false && gameOverManager.gameOver == false)
        {
            Resume();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EventSystem.current.SetSelectedGameObject(pauseButton.gameObject);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        mainMenuButton2.gameObject.SetActive(true);
        pauseHighScoreText.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EventSystem.current.SetSelectedGameObject(resumeButton.gameObject);

        pauseHighScoreText.text = "High Score: " + highScore;
    }

    public void GameOver()
    {
        retryButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(retryButton.gameObject);

        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

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
