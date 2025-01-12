using UnityEngine;
using UnityEngine.UI; // For UI components
using TMPro;          // For TextMeshPro components

public class KeywordAnalyzer : MonoBehaviour
{
    public TMP_InputField inputField; // Drag your InputField here
    public TextMeshProUGUI resultText; // Drag your result TextMeshPro here
    public Button analyzeButton; // Drag your Button here

    public void AnalyzeInput() // Must be public and have no parameters
    {
        Debug.Log("AnalyzeInput called!");

        if (inputField == null || resultText == null)
        {
            Debug.LogError("InputField or ResultText is not assigned in the Inspector!");
            return;
        }

        string userInput = inputField.text;

        if (string.IsNullOrWhiteSpace(userInput))
        {
            resultText.text = "Please enter some text.";
            return;
        }

        int totalWords = userInput.Split(' ').Length;
        int keywordCount = 0;

        string[] keywords = { "additionally", "furthermore", "however", "therefore", "moreover" };

        foreach (string keyword in keywords)
        {
            keywordCount += CountKeywordOccurrences(userInput, keyword);
        }

        float percentage = ((float)keywordCount / totalWords) * 100;
        resultText.text = $"Keyword Density: {percentage:F2}% ({keywordCount} keywords found in {totalWords} words)";
    }

    private int CountKeywordOccurrences(string text, string keyword)
    {
        int count = 0;
        int index = text.IndexOf(keyword, 0);

        while (index != -1)
        {
            count++;
            index = text.IndexOf(keyword, index + keyword.Length);
        }

        return count;
    }
}
