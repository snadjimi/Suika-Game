// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    // keeps track of how long a fruit has spent in the boxcollider that triggers the game over.
    private float timeInTrigger = 0f;
    // boolean that tells the program whether something is in the collider.
    private bool inTrigger = false;
    // creates a gameObject that will be assigned to the gameOverCanvas.
    public GameObject gameOverCanvas;

    void Update()
    {
        // Will check to see if one of the fruits is in the trigger area.
        if (inTrigger)
        {
           // increases the timer that tells the program how long a fruit has been in the collider.
            timeInTrigger += Time.deltaTime;

            // checks to see if the time in the collider has exceeded two seconds.
            if (timeInTrigger >= 2f)
            {
                // sets the gameOver screen to active once and object has exceeded 2 seconds in the trigger area.
                gameOverCanvas.SetActive(true);
                // resets the variable.
                inTrigger = false;
            }
        }
    }

    // called by the program when something enters the trigger.
    private void OnTriggerEnter2D(Collider2D fruit)
    {
        // sets the inTrigger boolean to true since something has entered the boxcollider.
        inTrigger = true;
        // sets the timer to 0 to start a fresh count for the fruit that just entered the collider.
        timeInTrigger = 0f;
    }

    // called when a fruit has exited the trigger area.
    private void OnTriggerExit2D(Collider2D fruit)
    {
        // sets the boolean isTrigger to false since the fruit has left the collider.
        inTrigger = false;
        // resets the timer for the next fruit to enter the collider.
        timeInTrigger = 0f;
    }
}
