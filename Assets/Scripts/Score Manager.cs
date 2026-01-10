// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // creates an instance for the scoreManager, and it can be accessed from other classes since it is static.
    public static ScoreManager Instance;

    // text mesh pro text object.
    public TextMeshProUGUI scoreDisplay;

    // creates a PRIVATE variable for the current score.
    private int currentScore;

    // uses the Awake() method that will run code while the script is loading.
    private void Awake()
    {
        // Checks to see if an instance of ScoreManager already exists.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // will destroy the instance of scoreManager if its not empty(null).
            Destroy(gameObject);
        }
    }

    // method that I used in all my classes to add to the score.
    public void AddScore(int points)
    {
        // increases the score using the method's argument.
        currentScore += points;

        // calls the UpdateScoreText method.
        UpdateScoreText();
    }

    // method used to obtain the current score(getter).
    public int returnScore()
    {
        // returns currentScore.
        return currentScore;
    }

    // method that will update the score text.
    public void UpdateScoreText()
    {
       // sets the textmeshpro text to the current score, but has to do so by first converting it to a string.
        scoreDisplay.text = currentScore.ToString();
        
    }
}
