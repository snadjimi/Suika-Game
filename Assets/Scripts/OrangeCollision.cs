// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class OrangeCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject applePrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both orange objects.
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
        // checks to see if both tags in the collision are "Orange."
        if (collision.gameObject.CompareTag("Orange"))
        {

            // makes sure that the program is not instantiating a second apple.
            if (!collision.gameObject.GetComponent<OrangeCollision>().isColliding)
            {
                // Instantiates an apple where the collision happened.
                Instantiate(applePrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(21);
            }

            // Sets the private boolean to true to prevent the script on the other orange from creating an apple.
            isColliding = true;
            collision.gameObject.GetComponent<OrangeCollision>().isColliding = true;

            // Destroys the two oranges that have already been replaced by the apple.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
