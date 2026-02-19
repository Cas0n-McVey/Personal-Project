using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
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
    public AudioMixer masterMixer;
    public static int carSelected = 0;

    private PlayerController playerControllerScript; 
    [SerializeField] private TextMeshProUGUI freeSampleText;
    [SerializeField] private TextMeshProUGUI hyperCarText;
    [SerializeField] private TextMeshProUGUI redHyperCarText;
    [SerializeField] private TextMeshProUGUI sportCarText;
    [SerializeField] private TextMeshProUGUI lowPolyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadPlayer();
        SetCarButton();
        // My music and sound effect
        music = GetComponent<AudioSource>();
        masterSlider.value = GetMasterVolume();
        soundSlider.value = GetSfxVolume();
        musicSlider.value = GetMusicVolume();
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

    public static void SavePlayer()
    {
        SaveSystem.SavePlayer(carSelected, GameManager.highScore);
    }

    public static void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        carSelected = data.carsSelected;
        GameManager.highScore = data.highScore;
    }

    public void FreeSample()
    {
        if(freeSampleText != null)
        {
            freeSampleText.text = "Selected";
            hyperCarText.text = "Select";
            redHyperCarText.text = "Select";
            sportCarText.text = "Select";
            lowPolyText.text = "Select";

            carSelected = 0;
            SavePlayer();
        }
    }

    public void HyperCar()
    {
        if (hyperCarText != null)
        {
            freeSampleText.text = "Select";
            hyperCarText.text = "Selected";
            redHyperCarText.text = "Select";
            sportCarText.text = "Select";
            lowPolyText.text = "Select";

            carSelected = 1;
            SavePlayer();
        }
    }

    public void RedHyperCar()
    {
        if (redHyperCarText != null)
        {
            freeSampleText.text = "Select";
            hyperCarText.text = "Select";
            redHyperCarText.text = "Selected";
            sportCarText.text = "Select";
            lowPolyText.text = "Select";

            carSelected = 2;
            SavePlayer();
        }
    }

    public void SportCar()
    {
        if (sportCarText != null)
        {
            freeSampleText.text = "Select";
            hyperCarText.text = "Select";
            redHyperCarText.text = "Select";
            sportCarText.text = "Selected";
            lowPolyText.text = "Select";

            carSelected = 3;
            SavePlayer();
        }
    }

    public void LowPoly()
    {
        if (lowPolyText != null)
        {
            freeSampleText.text = "Select";
            hyperCarText.text = "Select";
            redHyperCarText.text = "Select";
            sportCarText.text = "Select";
            lowPolyText.text = "Selected";

            carSelected = 4;
            SavePlayer();
        }
    }

    public void SetCarButton()
    {
        switch(carSelected)
        {
            case 0:
                freeSampleText.text = "Selected";
                hyperCarText.text = "Select";
                redHyperCarText.text = "Select";
                sportCarText.text = "Select";
                lowPolyText.text = "Select";
                break;
            case 1:
                freeSampleText.text = "Select";
                hyperCarText.text = "Selected";
                redHyperCarText.text = "Select";
                sportCarText.text = "Select";
                lowPolyText.text = "Select";
                break;
            case 2:
                freeSampleText.text = "Select";
                hyperCarText.text = "Select";
                redHyperCarText.text = "Selected";
                sportCarText.text = "Select";
                lowPolyText.text = "Select";
                break;
            case 3:
                freeSampleText.text = "Select";
                hyperCarText.text = "Select";
                redHyperCarText.text = "Select";
                sportCarText.text = "Selected";
                lowPolyText.text = "Select";
                break;
            case 4:
                freeSampleText.text = "Select";
                hyperCarText.text = "Select";
                redHyperCarText.text = "Select";
                sportCarText.text = "Select";
                lowPolyText.text = "Selected";
                break;

        }
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

    /// <summary>
    /// returns the music volume you assign in the setting
    /// </summary>
    /// <returns></returns>
    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1);
    }

    /// <summary>
    /// The sound level of the music
    /// </summary>
    /// <param name="soundLevel"></param>
    public void SetMusicVolume(float soundLevel)
    {
        PlayerPrefs.SetFloat("MusicVolume", soundLevel);
        masterMixer.SetFloat("MusicVol", soundLevel);
    }

    /// <summary>
    /// returns the sound volume you assign in the setting
    /// </summary>
    /// <returns></returns>
    public static float GetSfxVolume()
    {
        return PlayerPrefs.GetFloat("SFXVolume", 1);
    }

    /// <summary>
    /// The sound level of the sounds
    /// </summary>
    /// <param name="soundLevel"></param>
    public void SetSfxVolume(float soundLevel)
    {
        PlayerPrefs.SetFloat("SFXVolume", soundLevel);
        masterMixer.SetFloat("SFXVol", soundLevel);
    }

    /// <summary>
    /// returns the music and sound volume you assign in the setting
    /// </summary>
    /// <returns></returns>
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1);
    }

    /// <summary>
    ///  The sound level of the music and sounds
    /// </summary>
    /// <param name="soundLevel"></param>
    public void SetMasterVolume(float soundLevel)
    {
        PlayerPrefs.SetFloat("MasterVolume", soundLevel);
        masterMixer.SetFloat("MasterVol", soundLevel);
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
