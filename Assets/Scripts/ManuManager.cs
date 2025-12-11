using TMPro;
using UnityEditor;
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
    public Button exitButton;
    public Button carExitButton;
    public TextMeshProUGUI creditsText;
    public Canvas mainMenu;
    public Canvas creditMenu;
    public Canvas settingMenu;
    public Canvas carMenu;
    public Slider masterSlider;
    public Slider soundSlider;
    public Slider musicSlider;
    public AudioSource music;

    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartVideoGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CarManu()
    {
        mainMenu.gameObject.SetActive(false);

        carMenu.gameObject.SetActive(true);
        carExitButton.gameObject.SetActive(true);
    }

    public void CarExit()
    {
        mainMenu.gameObject.SetActive(true);

        carMenu.gameObject.SetActive(false);
        carExitButton.gameObject.SetActive(false);
    }

    public void Settings()
    {
        mainMenu.gameObject.SetActive(false);

        settingMenu.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void MasterVolume()
    {

    }

    public void Sound()
    {
        
    }

    public void Music()
    {
        
    }

    public void ExitSettings()
    {
        mainMenu.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        settingMenu.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void CreditMenu()
    {
        mainMenu.gameObject.SetActive(false);

        creditMenu.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(true);
        exitCreditsButton.gameObject.SetActive(true);
    }
    
    public void ExitCreditsMenu()
    {
        mainMenu.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        creditMenu.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
        exitCreditsButton.gameObject.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
