// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class DekoponCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject orangePrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both dekopon objects.
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
        // checks to see if both tags in the collision are "Dekopon."
        if (collision.gameObject.CompareTag("Dekopon"))
        {

            // makes sure that the program is not instantiating a second orange.
            if (!collision.gameObject.GetComponent<DekoponCollision>().isColliding)
            {
                // Instantiates a orange where the collision happened.
                Instantiate(orangePrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(15);
            }

            // Sets the private boolean to true to prevent the script on the other dekopon from creating an orange.
            isColliding = true;
            collision.gameObject.GetComponent<DekoponCollision>().isColliding = true;

            // Destroys the two dekopons that have already been replaced by the orange.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
