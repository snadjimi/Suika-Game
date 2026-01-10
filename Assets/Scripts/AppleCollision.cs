// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class AppleCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject pearPrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both apple objects.
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
        // checks to see if both tags in the collision are "Apple."
        if (collision.gameObject.CompareTag("Apple"))
        {

            // makes sure that the program is not instantiating a second pear.
            if (!collision.gameObject.GetComponent<AppleCollision>().isColliding)
            {
                // Instantiates a pear where the collision happened.
                Instantiate(pearPrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(28);
            }

            // Sets the private boolean to true to prevent the script on the other apple from creating a pear.
            isColliding = true;
            collision.gameObject.GetComponent<AppleCollision>().isColliding = true;

            // Destroys the two apples that have already been replaced by the pear.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
