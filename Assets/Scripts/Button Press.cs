// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonPress : MonoBehaviour
{
    // creates a canvas game object.
    public GameObject gameOverCanvas;
    // references a text mesh pro button.
    public TextMeshProUGUI button;


    public void buttonPressed()
    {
        // begins the resetGame coroutine.
        StartCoroutine(ResetGame());
    }

    // coroutine that I used to reset the game. I needed to use a coroutine to make sure that all prior operations
    // were done before I reset the game. When I didn't have this, the game was stuck in an infinite loop of reseting
    // the game.
    private IEnumerator ResetGame()
    {
        // goes through the entire game, finds all of the gameobjects, and puts them into this array.
        GameObject[] allFruits = GameObject.FindObjectsOfType<GameObject>();

        // loops through all of the gameObjects that the game found using a foreach loop.
        foreach (var fruit in allFruits)
        {
            // checks to see if the fruit ends with "Clone" or "_clone," since I specifically named them this when I created them.
            if (fruit.name.EndsWith("(Clone)") || fruit.name.EndsWith("_clone"))
            {
                Destroy(fruit);
            }
        }
        // uses the scoremanager getter to get the current score and save it into a variable.
        int currentScore = ScoreManager.Instance.returnScore();
        // subtracts the score by the current score(sets it to 0).
        ScoreManager.Instance.AddScore(-currentScore);
        // updates the score on the screen.
        ScoreManager.Instance.UpdateScoreText();
        // sets the start/end screen as off.
        gameOverCanvas.SetActive(false);

        // waits for the current frame to end, as well as all of the code above to execute.
        yield return new WaitForEndOfFrame();
        // reloads the game, now that all other things have happened.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
