// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class PineappleCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject melonPrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both pineapple objects.
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
        // checks to see if both tags in the collision are "Pineapple."
        if (collision.gameObject.CompareTag("Pineapple"))
        {

            // makes sure that the program is not instantiating a second melon.
            if (!collision.gameObject.GetComponent<PineappleCollision>().isColliding)
            {
                // Instantiates a melon where the collision happened.
                Instantiate(melonPrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(55);
            }

            // Sets the private boolean to true to prevent the script on the other pineapple from creating a melon.
            isColliding = true;
            collision.gameObject.GetComponent<PineappleCollision>().isColliding = true;

            // Destroys the two pineapples that have already been replaced by the melon.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
