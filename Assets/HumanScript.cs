using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject alienPlayer; // Drag the alien player object here in the inspector

    // Called when another collider enters the trigger collider of this GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is the alien player
        if (other.gameObject == alienPlayer)
        {
            // Print "Loses" and "Game Over"
            Debug.Log("Loses");
            Debug.Log("Game Over");

            // Add any other logic here for Game Over, like stopping the game
            Time.timeScale = 0; // This will stop the game
        }
    }
}
