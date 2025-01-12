using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    public void NextLevel()
    {
        // Load the next scene in the build order
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        // Load a scene by its name
        SceneManager.LoadSceneAsync(sceneName);
    }
}
