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

    private PlayerController playerControllerScript; 
    [SerializeField] private TextMeshProUGUI freeSampleText;
    [SerializeField] private TextMeshProUGUI hyperCarText;
    [SerializeField] private TextMeshProUGUI redHyperCarText;
    [SerializeField] private TextMeshProUGUI sportCarText;
    [SerializeField] private TextMeshProUGUI lowPolyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void FreeSample()
    {
        if(freeSampleText != null)
        {
            freeSampleText.text = "Selected";
        }
    }

    public void HyperCar()
    {
        if (hyperCarText != null)
        {
            hyperCarText.text = "Selected";
        }
    }

    public void RedHyperCar()
    {
        if (redHyperCarText != null)
        {
            redHyperCarText.text = "Selected";
        }
    }

    public void SportCar()
    {
        if (sportCarText != null)
        {
            sportCarText.text = "Selected";
        }
    }

    public void LowPoly()
    {
        if (lowPolyText != null)
        {
            lowPolyText.text = "Selected";
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
