using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button retryButton;
    public Button mainMenuButton;
    public GameObject spawnManager;
    public GameObject player;
    public TextMeshProUGUI gameOverText;

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
        mainMenuButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
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
