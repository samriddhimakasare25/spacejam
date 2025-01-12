using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("SampleScene"); // Replace with the exact name of your next level
    }
}
