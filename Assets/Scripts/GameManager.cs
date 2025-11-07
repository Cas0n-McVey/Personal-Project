using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button retryButton;
    public Button playButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button mainMenuButton;
    public Button quitButton;
    public Button exitCreditsButton;
    public Canvas mainMenu;
    public GameObject spawnManager;
    public GameObject player;

    private GameOverManager gameOverManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverManager = GameObject.Find("Player").GetComponent<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        retryButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        playButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
        spawnManager.SetActive(false);
    }

    public void StartGame()
    {
        playButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        spawnManager.SetActive(true);
    }
}
