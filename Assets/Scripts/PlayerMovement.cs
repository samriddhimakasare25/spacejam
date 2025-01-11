using UnityEngine;
using TMPro;

public class PromptManager : MonoBehaviour
{
    public TextMeshProUGUI promptText; // Drag the "Promat Text" here in Inspector
    public TMP_InputField responseField; // Drag the input field for the user response
    public TextMeshProUGUI feedbackText; // Optional: Text for feedback message

    private string[] prompts = new string[]
    {
        "Your ex wants to get back together. What do you do?",
        "You wake up in a spaceship with no memory. Write the first thing you say.",
        "A genie offers you unlimited wishes, but there's a catch. What's your first wish?"
    };

    private string[] keywords = new string[] { "furthermore", "however", "interestingly", "thus", "indeed" };

    private void Start()
    {
        GenerateNewPrompt();
        if (feedbackText != null)
            feedbackText.text = ""; // Clear any feedback initially
    }

    public void GenerateNewPrompt()
    {
        int randomIndex = Random.Range(0, prompts.Length);
        promptText.text = prompts[randomIndex];
        if (feedbackText != null)
            feedbackText.text = ""; // Reset feedback
        if (responseField != null)
            responseField.text = ""; // Clear input
    }

    public void EvaluateResponse()
    {
        string userResponse = responseField.text.ToLower();
        int score = 0;

        foreach (var keyword in keywords)
        {
            if (userResponse.Contains(keyword))
            {
                score += 20; // Add points for each keyword
            }
        }

        if (userResponse.Length > 50)
        {
            score += 20; // Bonus for longer responses
        }

        score = Mathf.Min(score, 100); // Cap at 100

        if (feedbackText != null)
        {
            if (score >= 80)
            {
                feedbackText.text = $"Score: {score}/100 - You Win!";
            }
            else
            {
                feedbackText.text = $"Score: {score}/100 - Try Again! Include more advanced language.";
            }
        }
    }
}
