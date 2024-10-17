using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _pewSlider, _sfxSlider;
    public Button _musicButton, _pewButton, _sfxButton;
    public Button _backButton; 

    public Color mutedColor = Color.grey;
    public Color unmutedColor = Color.white;

    private bool isMusicMuted = false;
    private bool isPewMuted = false;
    private bool isSfxMuted = false;

    public GameObject pauseMenu; // Reference to the pause menu
    public GameObject volumeMenu; // Reference to the volume menu

    void Start()
    {
        // Add the listener to the back button
        if (_backButton != null)
        {
            _backButton.onClick.AddListener(GoBackToPauseMenu);
        }
    }

    public void ToggleMusic()
    {
        isMusicMuted = !isMusicMuted;
        AudioManager.instance.ToggleMusic();
        UpdateButtonColor(_musicButton, isMusicMuted);
    }

    public void TogglePew()
    {
        isPewMuted = !isPewMuted;
        AudioManager.instance.TogglePew();
        UpdateButtonColor(_pewButton, isPewMuted);
    }

    public void ToggleSfx()
    {
        isSfxMuted = !isSfxMuted;
        AudioManager.instance.ToggleSfx();
        UpdateButtonColor(_sfxButton, isSfxMuted);
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
    }

    public void PewVolume()
    {
        AudioManager.instance.PewVolume(_pewSlider.value);
    }

    public void SfxVolume()
    {
        AudioManager.instance.SfxVolume(_sfxSlider.value);
    }

    private void UpdateButtonColor(Button button, bool isMuted)
    {
        if (isMuted)
        {
            button.GetComponent<Image>().color = mutedColor;
            Debug.Log("unmute");
        }
        else
        {
            button.GetComponent<Image>().color = unmutedColor;
            Debug.Log("unmute");


        }
    }

    public void GoBackToPauseMenu()
    {
        Debug.Log("Trying to go back to pause menu");

        // Check if references are set
        if (pauseMenu == null)
        {
            Debug.LogError("Pause menu reference is null");
        }

        if (volumeMenu == null)
        {
            Debug.LogError("Volume menu reference is null");
        }

        // Switch between menus
        if (pauseMenu != null && volumeMenu != null)
        {
            volumeMenu.SetActive(false); // Hide the volume menu
            pauseMenu.SetActive(true);    // Show the pause menu
        }
    }
}
