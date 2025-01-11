using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakePerson : MonoBehaviour
{
    public Transform respawnPoint;         // The position where the player will respawn
    public Animator memeAnimator;          // Reference to the Animator for the meme
    public float memeDisplayTime = 2f;     // Duration to display the meme
    public Text wrongMessageText;          // Reference to the UI Text for the "Wrong!" message

    private PlayerMovement myplayerMovement;

    void Start()
    {
        // Hide the meme and the "Wrong!" message at the start of the game
        memeAnimator.gameObject.SetActive(false);
        wrongMessageText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerMovement component from the player
            myplayerMovement = other.GetComponent<PlayerMovement>();

            // Disable player movement
            if (myplayerMovement != null)
            {
                myplayerMovement.canMove = false;
            }

            StartCoroutine(DisplayMemeAndRespawn(other));
        }
    }

    private IEnumerator DisplayMemeAndRespawn(Collider2D player)
    {
        // Display the "Wrong!" message
        wrongMessageText.gameObject.SetActive(true);
        wrongMessageText.text = "Wrong!";

        // Play the meme animation once
        memeAnimator.gameObject.SetActive(true);
        memeAnimator.Play("MemeAnimation"); // Ensure this matches the name of your animation clip

        // Wait for the specified duration of the meme
        yield return new WaitForSeconds(memeDisplayTime);

        // Hide the meme animation and the "Wrong!" message after they play
        memeAnimator.gameObject.SetActive(false);
        wrongMessageText.gameObject.SetActive(false);

        // Reset the player's position to the respawn point
        player.transform.position = respawnPoint.position;

        if (myplayerMovement != null)
        {
            myplayerMovement.canMove = true;
        }
    }
}
