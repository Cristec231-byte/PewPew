using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeUI());
    }

    IEnumerator InitializeUI()
    {
        yield return null;

        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
}
