using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageHitHandler : MonoBehaviour
{
    public string nextLevelName = "SampleScene"; // Name of the next level

    void OnCollisionEnter2D(Collision2D collision) // For 2D Physics
    {
        if (collision.gameObject.name == "Option 2") // Check if the correct image is hit
        {
            Debug.Log("Correct image hit! Loading the next level...");
            SceneManager.LoadScene(nextLevelName); // Load the next scene
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Use for Trigger-based detection
    {
        if (other.gameObject.name == "Option 2")
        {
            Debug.Log("Correct image touched! Loading the next level...");
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
