using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject scoreBoard;
    public GameObject levelSelect;

    void Start()
    {
        StartCoroutine(InitializeUI());
    }

    IEnumerator InitializeUI()
    {
        yield return null;

        mainMenu.SetActive(true);
        scoreBoard.SetActive(false);
        levelSelect.SetActive(false);
    }

    public void PlayGame()
    {
        Debug.Log("Went to Game Scene");
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToScoreboard()
    {
        Debug.Log("Went to Scoreboard");
        mainMenu.SetActive(false);
        scoreBoard.SetActive(true);
    }

    public void GoToMainMenu() // To Main Menu scene
    {
        Debug.Log("Went to Main Menu Scene");
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToLevelSelect()
    {
        Debug.Log("Went to Level Select");
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void ReturnToMainMenu() // To Main Menu canvas
    {
        Debug.Log("Went back to Main Menu");
        mainMenu.SetActive(true);
        scoreBoard.SetActive(false);
        levelSelect.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitted Game");
        Application.Quit();
    }
}
