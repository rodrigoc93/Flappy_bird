using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D newRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Text HighScoreText;
    private const string SCORE_KEY = "HighScore";
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt(SCORE_KEY, 0);
        HighScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            newRigidBody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 17 || transform.position.y < -17)
        {
            logic.GameOver();
            string json = JsonUtility.ToJson(HighScoreText);
            Debug.Log(json);
            int score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
            AddHighScore(score);

        }

    }

    public void AddHighScore(int newHighScore)
    {
        // Update the high score if the new score is higher
        if (newHighScore > highScore)
        {
            highScore = newHighScore;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt(SCORE_KEY, highScore);
            PlayerPrefs.Save();

            // Update the UI to show the new high score
            HighScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
