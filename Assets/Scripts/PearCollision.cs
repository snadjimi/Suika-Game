// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class PearCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject peachPrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both pear objects.
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
        // checks to see if both tags in the collision are "Pear."
        if (collision.gameObject.CompareTag("Pear"))
        {

            // makes sure that the program is not instantiating a second peach.
            if (!collision.gameObject.GetComponent<PearCollision>().isColliding)
            {
                // Instantiates a peach where the collision happened.
                Instantiate(peachPrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(36);
            }

            // Sets the private boolean to true to prevent the script on the other pear from creating a peach.
            isColliding = true;
            collision.gameObject.GetComponent<PearCollision>().isColliding = true;

            // Destroys the two pears that have already been replaced by the peach.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
