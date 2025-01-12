using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 5f; // Speed at which the object falls
    public bool isGood; // True if this is a "good" image, false if it's "bad"

    private bool isDestroyed = false; // Track if the object has already been destroyed

    private void Update()
    {
        if (isDestroyed) return; // Prevent further updates if the object is destroyed

        // Make the object fall
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Destroy the object if it goes out of bounds
        if (transform.position.y < -6f) // Adjust based on your screen size
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestroyed) return; // Prevent further actions if already destroyed

        // Check if the object collides with the player
        if (collision.CompareTag("Player"))
        {
            if (isGood)
            {
                Debug.Log("Good object hit! Keep playing!");
            }
            else
            {
                Debug.Log("Bad object hit! Quitting the game!");
                Application.Quit(); // Quit the game
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // For testing in Unity Editor
#endif
            }

            isDestroyed = true; // Mark the object as destroyed
            Destroy(gameObject); // Destroy the object
        }
    }
}
