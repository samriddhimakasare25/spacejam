using UnityEngine;
using TMPro; // For TextMeshPro components

public class RandomPromptGenerator : MonoBehaviour
{
    public TMP_Text promptText; // Text component for displaying prompts

    private string[] prompts = // List of random prompts
    {
        "Your Alien Girlfriend is mad at you write her a message.",
        "Why are computer science students losing jobs",
        "Aliens are boycotting Earth—what’s their reason?",
        "If you could travel anywhere, where would you go and why?",
        "What is your dream job and why?"
    };

    private void Start()
    {
        DisplayRandomPrompt(); // Show a random prompt when the scene starts
    }

    public void DisplayRandomPrompt()
    {
        if (promptText == null)
        {
            Debug.LogError("Prompt Text is not assigned in the Inspector!");
            return;
        }

        // Pick a random prompt from the list
        string randomPrompt = prompts[Random.Range(0, prompts.Length)];
        promptText.text = randomPrompt;
    }
}
