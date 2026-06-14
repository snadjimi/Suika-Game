// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // creates a gameObject that is later assigned in the unity editor.
    public GameObject Cloudy;
    // sets a speed of 5 for the cloud.
    public float speed = 5.0f;

    // adds a max and min x so that the cloud cannot go out of bounds and drop fruit everywhere.
    public float minX = -3.7f;
    public float maxX = 3.29f;

    void Update()
    {
        // checks to see if the user has pressed "A" or the left arrow key.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // moves the cloud left at the speed that I want(5 in this case).
            Cloudy.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        // checks to see if the user has pressed "D" or the right arrow key.
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // moves the cloud to the right.
            Cloudy.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // uses the Mathf.Clamp feature of unity to clamp the cloud between the min and max that I set.
        float clampedX = Mathf.Clamp(Cloudy.transform.position.x, minX, maxX);
        // moves cloudy.
        Cloudy.transform.position = new Vector3(clampedX, Cloudy.transform.position.y, Cloudy.transform.position.z);
    }
}
