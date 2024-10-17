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
    }

    // Change to Easy Mode Scene (SampleScene)
    public void PlayEasyMode()
    {
        Debug.Log("Went to Easy Scene (SampleScene)");
        SceneManager.LoadScene("SampleScene");
    }

    // Change to Medium Mode Scene
    public void PlayMediumMode()
    {
        Debug.Log("Went to Medium Scene");
        SceneManager.LoadScene("Medium");
    }

    // Change to Hard Mode Scene
    public void PlayHardMode()
    {
        Debug.Log("Went to Hard Scene");
        SceneManager.LoadScene("Hard");
    }

    // Go to How to Play Canvas
    public void GoToHowToPlay()
    {
        Debug.Log("Went to How to Play");
        mainMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
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
        levelSelect.SetActive(false);
    }

    // Quit the Game (doesn't work in Editor)
    public void QuitGame()
    {
        Debug.Log("Quitted Game");
        Application.Quit();
    }
}
