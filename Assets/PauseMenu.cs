using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game by resetting time scale to 1
    }

    public void Home()
    {
        Time.timeScale = 1f; // Reset time scale before loading a new scene
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Reset time scale before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
