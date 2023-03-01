using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text scoreText;
    private const string SCORE_KEY = "HighScore";
    private int highScore = 0;

    private void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt(SCORE_KEY, 0);

        // Display the high score in the UI
        scoreText.text = "High Score: " + highScore;
    }

    public void AddHighScore(int score)
    {
        // Update the high score if the current score is higher
        if (score > highScore)
        {
            highScore = score;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt(SCORE_KEY, highScore);
            PlayerPrefs.Save();

            // Update the UI to show the new high score
            scoreText.text = "High Score: " + highScore;
        }
    }
}
