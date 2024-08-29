using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject scoreBoard;

    void Start()
    {
        mainMenu.SetActive(true);
        scoreBoard.SetActive(false);
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

    public void ReturnToMainMenu()
    {
        Debug.Log("Went back to Main Menu");
        mainMenu.SetActive(true);
        scoreBoard.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitted Game");
        Application.Quit();
    }
}
