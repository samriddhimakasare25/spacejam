using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int score = 0;  // Player score


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with the alien player
        if (other.gameObject.CompareTag("AlienPlayer")) // Make sure your alien has the "alien" tag
        {
            // Increment the score
            score += 1;
            Debug.Log("Score: " + score);

            // Check if the player has won
            if (score >= 10)
            {
                Debug.Log("You Win!");
                // Add win logic here, like showing a win screen or stopping the game
            }

            // Destroy the AI text object after the collision
            Destroy(gameObject); // This will remove the AI text object from the scene
        }
    }
}

