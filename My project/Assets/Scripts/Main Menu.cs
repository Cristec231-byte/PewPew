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

    // EASY SCENES

    // Change to Easy Mode Scene (SampleScene)
    public void PlayEasyMode()
    {
        Debug.Log("Went to Easy Scene (SampleScene)");
        SceneManager.LoadScene("SampleScene");
    }

    // Change to Easy 2
    public void PlayEasyMode2()
    {
        Debug.Log("Went to Easy Scene 2");
        SceneManager.LoadScene("Easy2");
    }

    // Change to Easy 3
    public void PlayEasyMode3()
    {
        Debug.Log("Went to Easy Scene 3");
        SceneManager.LoadScene("Easy3");
    }

    // MEDIUM SCENES

    // Change to Medium Mode Scene
    public void PlayMediumMode()
    {
        Debug.Log("Went to Medium Scene");
        SceneManager.LoadScene("Medium");
    }

    // Change to Medium 2
    public void PlayMediumMode2()
    {
        Debug.Log("Went to Medium Scene 2");
        SceneManager.LoadScene("Medium2");
    }

    // Change to Medium 3
    public void PlayMediumMode3()
    {
        Debug.Log("Went to Medium Scene 3");
        SceneManager.LoadScene("Medium3");
    }

    // HARD SCENES

    // Change to Hard Mode Scene
    public void PlayHardMode()
    {
        Debug.Log("Went to Hard Scene");
        SceneManager.LoadScene("Hard");
    }
    
    // Change to Hard 2
    public void PlayHardMode2()
    {
        Debug.Log("Went to Hard Scene 2");
        SceneManager.LoadScene("Hard 2");
    }

    // Change to Hard 3
    public void PlayHardMode3()
    {
        Debug.Log("Went to Hard Scene 3");
        SceneManager.LoadScene("Hard 3");
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
