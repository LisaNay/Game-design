using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Panels List")]
    public GameObject mainPanel;
    public GameObject vidPanel;
    public GameObject audioPanel;
    public GameObject optionsPanel;
    public GameObject keyboardPanel;
    [Header("Toggle & Dropdown List")]
    public Toggle vSyncToggle;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    [Header("Default selected button on panel")]
    public GameObject defaultButtonMain;
    public GameObject defaultButtonOptions;
    public GameObject defaultButtonVideo;
    public GameObject defaultButtonAudio;
    public GameObject defaultButtonKeyboard;

    // VIDEO

    // Vsync Boolean
    private Boolean isVsync;
    // Fullscreen Boolean
    private Boolean isFullScreen;
    // Active screenResolution / index of the resolution Dropdown
    private int activeScreenResIndex;
    // Last index in the resolution Dropdown
    internal static int beforeRes;
    // Last Fullscreen / Vsync toggle value
    internal static bool beforeFull;
    internal static bool beforeVsync;


    // AUDIO        

    [Header("Audio Settings")]
    /// <summary>
    /// The volume control sliders.
    /// </summary>
    public Slider[] volumeControl;
    /// <summary>
    /// The button sfx AudioClip.
    /// </summary>
    public AudioClip buttonsfx;
    //last master / effect / music values 
    internal static float beforeMaster;
    internal static float beforeMusic;
    internal static float beforeSfx;
		     
    // OTHER

    [Header("Other Settings")]
    // The mask makes the scene darker
    public GameObject mask;
    // Used to pause the game
    public float timeScale = 1f;
    // String used to load the main menu
    public String loadMainMenu;
    // An array of the other UI elements, which is used for disabling the other elements when the game is paused.
    public GameObject[] otherUIElements;
    // Take the "Event system" to select the 1rst button on different panel
    public EventSystem uiEventSystem;


    public void Start () {
        activeScreenResIndex = PlayerPrefs.GetInt ("screen res index");
        isFullScreen = (PlayerPrefs.GetInt ("fullscreen") == 1)?true:false;
        isVsync = (PlayerPrefs.GetInt ("vsync") == 1)?true:false;

        /*
         * Set all variable (slider/toggle/etc..) 
         * grant possibility to cancel safely and keep the previousy set value when there is no change in the option
         */
        beforeMaster = volumeControl [0].value = AudioManager.instance.masterVolumePercent;
        beforeMusic = volumeControl [1].value = AudioManager.instance.musicVolumePercent;
        beforeSfx = volumeControl [2].value = AudioManager.instance.sfxVolumePercent;
        beforeRes = activeScreenResIndex;
        //resolutionDropdown.value = beforeRes;
        beforeRes = activeScreenResIndex;
        beforeFull = fullscreenToggle.isOn = isFullScreen;
        beforeVsync = vSyncToggle.isOn = isVsync;


        // Set the first selected item
        uiEventSystem.firstSelectedGameObject = defaultButtonMain;

        // Disable other panels
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (false);
        keyboardPanel.SetActive (false);
        // Disable mask
        mask.SetActive (false);

        // Populate and set the dropdown list
        FillScreenResolutionDropdown();
    }

    /// <summary>
    /// Resume the game, disable the pause menu and re-enable all other ui elements.
    /// </summary>
    public void Resume () {
        Time.timeScale = timeScale;

        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (false);
        keyboardPanel.SetActive (false);

        mask.SetActive (false);
        for (int i = 0; i < otherUIElements.Length; i++) 
        {
            otherUIElements [i].gameObject.SetActive (true);
        }
    }

    /// <summary>
    /// Quits the game even in the Unity Editor.
    /// </summary>
    public void quitGame () {
        Application.Quit ();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // button for an alpha ?
    public void returnToMenu () {
        SceneManager.LoadScene (loadMainMenu);
    }
        
    public void Update () {
        if (Input.GetKeyDown (KeyCode.Escape) && mainPanel.activeInHierarchy == false) {
            AudioManager.instance.PlaySound2D ("Button Sfx");

            uiEventSystem.SetSelectedGameObject (defaultButtonMain);
            mainPanel.SetActive (true);
            vidPanel.SetActive (false);
            audioPanel.SetActive (false);
            optionsPanel.SetActive (false);
            keyboardPanel.SetActive (false);
            mask.SetActive (true);
            Time.timeScale = 0;

            for (int i = 0; i < otherUIElements.Length; i++) 
            {
                otherUIElements [i].gameObject.SetActive (false);
            }
        } else if (Input.GetKeyDown (KeyCode.Escape) && mainPanel.activeInHierarchy == true) {
            Time.timeScale = timeScale;
            mainPanel.SetActive (false);
            vidPanel.SetActive (false);
            audioPanel.SetActive (false);
            optionsPanel.SetActive (false);
            keyboardPanel.SetActive (false);
            mask.SetActive (false);

            for (int i = 0; i < otherUIElements.Length; i++) 
            {
                otherUIElements [i].gameObject.SetActive (true);
            }      
        }
    }

    ///// AUDIO PANEL

    /// <summary>
    /// Show the audio panel.
    /// </summary>
    public void Audio () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        optionsPanel.SetActive (false);
        optionsPanel.SetActive (false);
        audioPanel.SetActive (true);
        keyboardPanel.SetActive (false);

        uiEventSystem.SetSelectedGameObject (defaultButtonAudio);
    }

    /// <summary>
    /// Updates the master vol2
    /// </summary>
    /// <param name="f">F.</param>
    public void updateMasterVol (float f) {
        AudioManager.instance.SetVolume (f, AudioManager.AudioChannel.Master);
    }

    /// <summary>
    /// Updates the music vol.
    /// </summary>
    /// <param name="f">F.</param>
    public void updateMusicVol (float f) {
        AudioManager.instance.SetVolume (f, AudioManager.AudioChannel.Music);
    }

    /// <summary>
    /// Updates the sfx vol.
    /// </summary>
    /// <param name="f">F.</param>
    public void updateSfxVol (float f) {
        AudioManager.instance.SetVolume (f, AudioManager.AudioChannel.Sfx);
    }
        
    public void applyAudio () {
        applyAudioMain ();
        uiEventSystem.SetSelectedGameObject (defaultButtonOptions);
    }

    /// <summary>
    /// Apply the new audio settings.
    /// </summary>
    public void applyAudioMain () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (true);
        keyboardPanel.SetActive (false);

        beforeMaster = volumeControl [0].value;
        beforeMusic = volumeControl [1].value;
        beforeSfx = volumeControl [2].value;
    }
        
    public void cancelAudio () {
        uiEventSystem.SetSelectedGameObject (defaultButtonOptions);
        cancelAudioMain ();
    }

    /// <summary>
    /// Cancels the new audio settings.
    /// </summary>
    public void cancelAudioMain () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        optionsPanel.SetActive (true);
        audioPanel.SetActive (false);
        keyboardPanel.SetActive (false);

        volumeControl [0].value = beforeMaster;
        volumeControl [1].value = beforeMusic;
        volumeControl [2].value = beforeSfx;
    }

    //// VIDEO PANEL

    /// <summary>
    /// Show the Video panel.
    /// </summary>
    public void Video () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (true);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (false);
        keyboardPanel.SetActive (false);

        uiEventSystem.SetSelectedGameObject (defaultButtonVideo);
    }
        
    public void toggleVSync (Boolean isVsync) {
        if (isVsync == true) {
            QualitySettings.vSyncCount = 1;
        } else {
            QualitySettings.vSyncCount = 0;
        }

        PlayerPrefs.SetInt ("vsync", ((isVsync) ? 1 : 0));
        PlayerPrefs.Save ();
    }

    /// <summary>
    /// Cancels the new audio settings.
    /// </summary>
    public void cancelVideoMain () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (true);
        keyboardPanel.SetActive (false);

        resolutionDropdown.value = beforeRes;
        vSyncToggle.isOn = beforeVsync;
        fullscreenToggle.isOn = beforeFull;
       
        uiEventSystem.SetSelectedGameObject (defaultButtonOptions);
    }

    public void apply () {
        applyVideo ();
    }

    /// <summary>
    /// Apply the new video settings.
    /// </summary>
    public void applyVideo () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (true);
        keyboardPanel.SetActive (false);

        beforeVsync = vSyncToggle.isOn;
        beforeFull = fullscreenToggle.isOn;
        beforeRes = activeScreenResIndex;

        uiEventSystem.SetSelectedGameObject (defaultButtonOptions);
    }

    /// <summary>
    /// Sets the full screen.
    /// </summary>
    /// <param name="isFullScreen">If set to <c>true</c> is full screen.</param>
    public void setFullScreen (Boolean isFullScreen) {
        // if fullscreen is checked the game looks for the maximun native size of the screen
        if (isFullScreen == true) {
            resolutionDropdown.value = 0;
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions [allResolutions.Length - 1];
            Screen.SetResolution (maxResolution.width, maxResolution.height, true);
        } else {
            resolutionDropdown.value = 0;
            Screen.SetResolution (1920, 1080, false);
            //setDropdownScreenResolution (activeScreenResIndex);
        }

        PlayerPrefs.SetInt ("fullscreen", ((isFullScreen) ? 1 : 0));
        PlayerPrefs.Save ();
    }

    /// <summary>
    /// Fills the screen resolution dropdown.
    /// </summary>
    public void FillScreenResolutionDropdown () {
        List<string> allRes = new List<string> () { "1920 X 1080", "1280 X 800", "1280 X 720" };
        resolutionDropdown.AddOptions(allRes);
    }

    /// <summary>
    /// Sets the dropdown screen resolution.
    /// </summary>
    /// <param name="index">Index.</param>
    public void setDropdownScreenResolution (int index) {
        if (index == 0) {
            activeScreenResIndex = index;
            if (Screen.fullScreen == true)
                Screen.SetResolution (1920, 1080, true);
            else
            Screen.SetResolution (1920, 1080, false);
        }
        else if (index == 1) {
            activeScreenResIndex = index;
            if (Screen.fullScreen == true)
                Screen.SetResolution (1280, 800, true);
            else
            Screen.SetResolution (1280, 800, false);
        }
        else {
            activeScreenResIndex = index;
            if (Screen.fullScreen == true)
                Screen.SetResolution (1280, 720, true);
            else
            Screen.SetResolution (1280, 720, false);
        }
            
        PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
        PlayerPrefs.Save ();
    }

    /////OPTIONS PANEL


    /// <summary>
    /// Show the Option panel.
    /// </summary> 
    public void Options () {
        uiEventSystem.SetSelectedGameObject (defaultButtonOptions);

        optionsPanel.SetActive (true);
        mainPanel.SetActive (false);
        audioPanel.SetActive (false);
        vidPanel.SetActive (false);
        keyboardPanel.SetActive (false);
    }

    public void quitOptions () {
        mainPanel.SetActive (true);
        vidPanel.SetActive (false);
        audioPanel.SetActive (false);
        optionsPanel.SetActive (false);
        keyboardPanel.SetActive (false);

        uiEventSystem.SetSelectedGameObject (defaultButtonMain);
    }

            
    /////KEYBOARD PANEL
      
    /// <summary>
    /// Show the Keyboard panel.
    /// </summary>
    public void keyboard () {
        uiEventSystem.SetSelectedGameObject (defaultButtonKeyboard);

        optionsPanel.SetActive (false);
        mainPanel.SetActive (false);
        audioPanel.SetActive (false);
        vidPanel.SetActive (false);
        keyboardPanel.SetActive (true);
    }

    //  TO DO
    public void applyKeyboard () {}

    /// <summary>
    /// Cancels the new keyboard settings.
    /// </summary>
    public void cancelKeyboard () {
        mainPanel.SetActive (false);
        vidPanel.SetActive (false);
        optionsPanel.SetActive (true);
        audioPanel.SetActive (false);
        keyboardPanel.SetActive (false);

        uiEventSystem.SetSelectedGameObject (defaultButtonOptions);
    }

}

