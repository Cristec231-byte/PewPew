using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject volumeMenu; // Reference to the volume menu
    public Button volumeButton; // Reference to the Volume button

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeUI());

        // Add listener to the Volume button
        if (volumeButton != null)
        {
            volumeButton.onClick.AddListener(GoToVolumeMenu);
        }
    }

    IEnumerator InitializeUI()
    {
        yield return null;

        volumeMenu.SetActive(false);

        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if the volume menu is active
            if (volumeMenu.activeSelf)
            {
                return; // Do nothing if the volume menu is open
            }

            if (isPaused)
            {
                // Game unpauses if there's no inventory present
                if (InventoryManager.menuActivated)
                {
                    ClosePauseMenuOnly();
                }
                else
                {
                    ResumeGame();
                }
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game paused");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game resumed");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // If player unpauses game while inventory is shown it will only dismiss the Pause Menu.
    public void ClosePauseMenuOnly()
    {
        Debug.Log("Closed pause menu, game still paused due to inventory");
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void GoToVolumeMenu()
    {
        // Disable the pause menu and enable the volume menu
        pauseMenu.SetActive(false); // Hide the pause menu
        volumeMenu.SetActive(true);  // Show the volume menu
    }


}
