// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class GrapeCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject dekoponPrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both grape objects.
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
        // checks to see if both tags in the collision are "Grapes."
        if (collision.gameObject.CompareTag("Grapes"))
        {

            // makes sure that the program is not instantiating a second dekopon.
            if (!collision.gameObject.GetComponent<GrapeCollision>().isColliding)
            {
                // Instantiates a dekopon where the collision happened.
                Instantiate(dekoponPrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(10);
            }

            // Sets the private boolean to true to prevent the script on the other grape from creating a dekopon.
            isColliding = true;
            collision.gameObject.GetComponent<GrapeCollision>().isColliding = true;

            // Destroys the two grapes that have already been replaced by the dekopon.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
