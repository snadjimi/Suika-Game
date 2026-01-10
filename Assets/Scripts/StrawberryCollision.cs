// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class StrawberryCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject grapePrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both strawberry objects.
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
        // checks to see if both tags in the collision are "Strawberry."
        if (collision.gameObject.CompareTag("Strawberry"))
        {

            // makes sure that the program is not instantiating a second grape.
            if (!collision.gameObject.GetComponent<StrawberryCollision>().isColliding)
            {
                // Instantiates a grape where the collision happened.
                Instantiate(grapePrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(6);
            }

            // Sets the private boolean to true to prevent the script on the other strawberry from creating a grape.
            isColliding = true;
            collision.gameObject.GetComponent<StrawberryCollision>().isColliding = true;

            // Destroys the two strawberries that have already been replaced by the grape.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
