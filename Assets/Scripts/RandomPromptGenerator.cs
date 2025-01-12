using UnityEngine;
using TMPro; // For TextMeshPro components

public class RandomPromptGenerator : MonoBehaviour
{
    public TMP_Text promptText; // Text component for displaying prompts

    private string[] prompts = // List of random prompts
    {
        "Describe a memorable day in your life.",
        "Explain how technology has changed the world.",
        "What are your goals for the next 5 years?",
        "Describe your favorite movie and why you like it.",
        "If you could travel anywhere, where would you go and why?",
        "Explain how you would solve a complex problem.",
        "What is your favorite book and why do you enjoy it?",
        "Discuss a time when you overcame a challenge.",
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
