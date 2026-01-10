// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;
using TMPro;

public class CherryCollision : MonoBehaviour
{
    // creates a gameObject that is passed to the program through the unity screen.
    public GameObject strawberryPrefab;
    // creates a private boolean that will flag when the first collision happens.
    // I added this because I was having a problem with the reaction happening twice
    // since this script would be attached to both cherry objects.
    private bool isColliding = false;
    // creates a textMeshPro object that is assigned in unity. This will display the score.
    

    

    // will run when a 2d collision is detected.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // checks to see if the reaction has already occurred.
        if (isColliding) { 
        
            // if it has already occurred, it will exit.
            return;
        }
        // checks to see if both tags in the collision are "Cherry."
        if (collision.gameObject.CompareTag("Cherry"))
        {

            // makes sure that the program is not instantiating a second strawberry.
            if (!collision.gameObject.GetComponent<CherryCollision>().isColliding)
            {
                // Instantiates a strawberry where the collision happened.
                Instantiate(strawberryPrefab, transform.position, Quaternion.identity);
                ScoreManager.Instance.AddScore(3);



            }

            // Sets the private boolean to true to prevent the script on the other cherry from creating a strawberry.
            isColliding = true;
            collision.gameObject.GetComponent<CherryCollision>().isColliding = true;

            // Destroys the two cherries that have already been replaced by the strawberry.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
