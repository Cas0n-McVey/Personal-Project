using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManuManager : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button quitButton;
    public Button exitCreditsButton;
    public TextMeshProUGUI creditsText;
    public Canvas mainMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartVideoGame()
    {
        SceneManager.LoadScene(1);
    }
}
