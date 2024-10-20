using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu; // Main Menu Canvas
    public GameObject howToPlayMenu; // How to Play Canvas
    public GameObject levelSelect; // Level Select Canvas
    public GameObject characterSelect; // Character Select Canvas
    public GameObject graphicsMenu; // Settings Canvas
    public GameObject scoreboardMenu; // Scoreboard Menu

    public GameObject levelSelect2; // Janmie
    public GameObject levelSelect3; // C-602

    void Start()
    {
        StartCoroutine(InitializeUI());
    }

    // This is to make sure every UI component is loaded properly
    IEnumerator InitializeUI()
    {
        yield return null;

        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        levelSelect.SetActive(false);
        characterSelect.SetActive(false);
        graphicsMenu.SetActive(false);
        scoreboardMenu.SetActive(false);

        levelSelect2.SetActive(false);
        levelSelect3.SetActive(false);
    }

    // Go to How to Play Canvas
    public void GoToHowToPlay()
    {
        Debug.Log("Went to How to Play");
        mainMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
    }

    // Go to Settings Canvas
    public void GoToSettings()
    {
        Debug.Log("Went to Settings");
        mainMenu.SetActive(false);
        graphicsMenu.SetActive(true);
    }

    // Go to Scoreboard Canvas
    public void GoToScoreboard()
    {
        Debug.Log("Went to Scoreboard");
        mainMenu.SetActive(false);
        scoreboardMenu.SetActive(true);
    }

    // Go to Character Select Canvas
    public void GoToCharacterSelect()
    {
        Debug.Log("Went to Character Select");
        characterSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    // To Main Menu Scene
    public void GoToMainMenu()
    {
        Debug.Log("Went to Main Menu Scene");
        SceneManager.LoadScene("Main Menu");
    }

    // Go to Level Select Canvas
    public void GoToLevelSelect()
    {
        Debug.Log("Went to Level Select");
        characterSelect.SetActive(false);
        levelSelect.SetActive(true);
    }

    // (Return) Go to Main Menu Canvas
    public void ReturnToMainMenu() // To Main Menu canvas
    {
        Debug.Log("Went back to Main Menu");
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        scoreboardMenu.SetActive(false);
    }

    // Quit the Game (doesn't work in Editor)
    public void QuitGame()
    {
        Debug.Log("Quitted Game");
        Application.Quit();
    }
}
