using UnityEngine;
using UnityEngine.UI; // For UI components
using TMPro;          // For TextMeshPro components
using UnityEngine.SceneManagement; // For SceneManager
using System.Collections; // For Coroutines

public class KeywordAnalyzer : MonoBehaviour
{
    public TMP_InputField inputField; // Drag your InputField here
    public TextMeshProUGUI resultText; // Drag your result TextMeshPro here
    public Button analyzeButton; // Drag your Button here

    public string nextSceneName; // Specify the name of the success scene in the Inspector
    public string failSceneName = "Fail"; // Default fail scene name is "Fail"
    public float delayInSeconds = 5f; // Set the delay time to 5 seconds
    private int remainingAttempts = 3; // Number of attempts allowed

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

        string[] keywords = {
            "analysis", "argument", "assessment", "cause", "conclusion", "context", "critical", "debate", "definition", "development",
            "furthermore", "moreover", "additionally", "however", "therefore", "consequently", "nevertheless", "whereas", "although", "thus",
            "significant", "important", "crucial", "essential", "relevant", "evident", "noteworthy", "key", "major", "fundamental",
            "demonstrate", "highlight", "illustrate", "emphasize", "suggest", "argue", "indicate", "imply", "analyze", "examine",
            "similar", "contrast", "different", "related", "comparable", "opposing", "distinct", "parallel", "correlate", "equivalent",
            "address", "approach", "challenge", "impact", "influence", "investigate", "explore", "observe", "propose", "respond",
            "summarize", "conclude", "synthesize", "determine", "reflect", "recommend", "resolve", "affirm", "endorse", "verify",
            "hypothesis", "framework", "theory", "research", "method", "finding", "evidence", "data", "observation", "study",
            "idea", "belief", "concept", "value", "principle", "structure", "system", "strategy", "model", "perspective",
            "approach", "benefit", "factor", "issue", "process", "result", "solution", "trend", "aspect", "element"
        };

        foreach (string keyword in keywords)
        {
            keywordCount += CountKeywordOccurrences(userInput, keyword);
        }

        float percentage = ((float)keywordCount / totalWords) * 100;

        if (percentage > 80)
        {
            resultText.text = $"AI Score: {percentage:F2}% - Great job!";
            Debug.Log($"Score is {percentage:F2}%. Starting delay of {delayInSeconds} seconds.");
            StartCoroutine(LoadNextSceneAfterDelay());
        }
        else
        {
            remainingAttempts--;
            if (remainingAttempts > 0)
            {
                resultText.text = $"AI Score: {percentage:F2}% - Oh no, try again! Remaining attempts: {remainingAttempts}";
                Debug.Log($"Score is {percentage:F2}%. Remaining attempts: {remainingAttempts}");
            }
            else
            {
                resultText.text = "You have used all attempts!";
                Debug.Log("No remaining attempts. Loading fail scene.");
                StartCoroutine(LoadFailSceneAfterDelay());
            }
        }
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

    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator LoadFailSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(failSceneName);
    }

    public void RestartGame()
    {
        // Call RandomPromptGenerator to display a new prompt
        FindObjectOfType<RandomPromptGenerator>().DisplayRandomPrompt();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
