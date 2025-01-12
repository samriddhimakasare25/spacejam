using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageScore : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManageScore Instance;
    public Text textScore;
    private int score = 0;

    public int scoreToWin = 3;


    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points) {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText() {

        if (textScore != null) {
            textScore.text = "Score: " + score.ToString();
            if(score == scoreToWin)
            {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
