using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealPerson : MonoBehaviour
{
    public Animator memeAnimator;          // Reference to the Animator for the meme
    public float memeDisplayTime = 2f;     // Duration to display the meme
    public Text correctMessageText;        // Reference to the UI Text for the "Correct!" message

    private PlayerMovement myPlayerMovement;

    void Start()
    {
        // Hide the meme and the "Correct!" message at the start of the game
        memeAnimator.gameObject.SetActive(false);
        correctMessageText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerMovement component from the player
            myPlayerMovement = other.GetComponent<PlayerMovement>();

            // Disable player movement
            if (myPlayerMovement != null)
            {
                myPlayerMovement.canMove = false;
            }

            StartCoroutine(DisplayCorrectMeme());
        }
    }

    private IEnumerator DisplayCorrectMeme()
    {
        // Display the "Correct!" message
        correctMessageText.gameObject.SetActive(true);
        correctMessageText.text = "Correct!";

        // Play the meme animation once
        memeAnimator.gameObject.SetActive(true);
        memeAnimator.Play("MemeAnimation"); // Ensure this matches the name of your animation clip

        // Wait for the specified duration of the meme
        yield return new WaitForSeconds(memeDisplayTime);

        // Hide the meme animation and the "Correct!" message after they play
        memeAnimator.gameObject.SetActive(false);
        correctMessageText.gameObject.SetActive(false);

        // Re-enable player movement
        if (myPlayerMovement != null)
        {
            myPlayerMovement.canMove = true;
        }
    }
}
