// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class melonCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject watermelonPrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both melon objects.
    private bool isColliding = false;

    // will run when a 2d collision is detected.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // checks to see if the reaction has already occurred.
        if (isColliding)
        {

            // if it has already occurred, it will exit.
            return;
        }
        // checks to see if both tags in the collision are "Melon."
        if (collision.gameObject.CompareTag("Melon"))
        {

            // makes sure that the program is not instantiating a second watermelon.
            if (!collision.gameObject.GetComponent<melonCollision>().isColliding)
            {
                // Instantiates a watermelon where the collision happened.
                Instantiate(watermelonPrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(66);
            }

            // Sets the private boolean to true to prevent the script on the other melon from creating a watermelon.
            isColliding = true;
            collision.gameObject.GetComponent<melonCollision>().isColliding = true;

            // Destroys the two melons that have already been replaced by the watermelon.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
