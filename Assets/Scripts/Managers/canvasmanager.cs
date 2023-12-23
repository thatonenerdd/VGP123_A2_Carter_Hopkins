using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Audio;

public class canvasmanager : MonoBehaviour
{
    public AudioMixer audiomixer;
    [Header("Button")]
    public Button playButton;
    public Button quitButton;
    public Button settingsbutton;
    public Button backButton;
    public Button returnToMenu;
    public Button returnToGame;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;


    [Header("Text")]
    public Text livesText;
    public Text scoreText;
    public Text masterslidertext;
    public Text musicslidertext;
    public Text sfxslidertext;

    [Header("slider")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

 
    // Start is called before the first frame update
    void Start()
    {
        if (playButton)
            playButton.onClick.AddListener(() => gamemanager.Instance.ChangeScene(1));


        if (settingsbutton)
            settingsbutton.onClick.AddListener(ShowSettingsMenu);
        if (backButton)
            backButton.onClick.AddListener(ShowMainMenu);
        if (quitButton)
            quitButton.onClick.AddListener(Quit);

        if(livesText)
        {
            gamemanager.Instance.OnLivesValueChanged.AddListener((value) => UpdateLivesText(value));
            livesText.text = "Lives: " + gamemanager.Instance.Lives.ToString();

        }
      
        if (masterSlider)
        {
            masterSlider.onValueChanged.AddListener((value) => OnSliderValueChanged(value));
           
            float newValue;
            audiomixer.GetFloat("Master", out newValue);
            masterSlider.value = newValue + 80;
            if (masterslidertext)
            masterslidertext.text = (Mathf.Ceil(newValue + 80).ToString());
        }


        if (musicSlider)
        {
            musicSlider.onValueChanged.AddListener((value) => OnMusicSliderValueChanged(value));
           
            float newValue;
            audiomixer.GetFloat("Music", out newValue);
            musicSlider.value = newValue + 80;
            if (musicslidertext)
               
            musicslidertext.text = (Mathf.Ceil(newValue + 80).ToString());

        }
        if (sfxSlider)
        {
            sfxSlider.onValueChanged.AddListener((value) => OnsfxSliderValueChanged(value));
            
            float newValue;
            audiomixer.GetFloat("SFX", out newValue);
            sfxSlider.value = newValue + 80;
            if (sfxslidertext)
                
            sfxslidertext.text = (Mathf.Ceil(newValue + 80).ToString());
        }

        if (returnToMenu)
            returnToMenu.onClick.AddListener(() => gamemanager.Instance.ChangeScene(0));
        if (returnToGame)
            returnToGame.onClick.AddListener(UnPauseGame);
    }
    void UpdateLivesText(int value)
    {
        if (livesText)
            livesText.text = "Lives " + value.ToString();
    }
    void UpdateScoretext(int value)
    {
        if (scoreText)
            scoreText.text = "Score " + value.ToString();
    }
    
    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    void UnPauseGame()
    {
        pauseMenu.SetActive(false);
    }
    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
    void OnSliderValueChanged(float value)
    {
        masterslidertext.text = value.ToString();
        audiomixer.SetFloat("Master", value - 80);
    }
    void OnMusicSliderValueChanged(float value)
    {
        musicslidertext.text = value.ToString();
        audiomixer.SetFloat("Music", value - 80);
    }
    void OnsfxSliderValueChanged(float value)
    {
        sfxslidertext.text = value.ToString();
        audiomixer.SetFloat("SFX", value - 80);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu) return;

        if(Input.GetKeyDown(KeyCode.P))
        {

            pauseMenu.SetActive(!pauseMenu.activeSelf);

            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
