using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverCanvas; // Reference to the Game Over Canvas
    public Button restartButton; // Reference to the restart button

    private Timer timer;

    void Start()
    {

        // Find the Timer script in the scene
        timer = FindObjectOfType<Timer>();

        // Ensure the game over screen is hidden at the start
        gameOverCanvas.SetActive(false);

        // Add listener to the restart button
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverCanvas.SetActive(true);

        // Stop the timer if it exists
        if (timer != null)
        {
            timer.StopTimer();
        }
    }

    private void RestartGame()
    {
        // Reload the current scene to restart the game
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
