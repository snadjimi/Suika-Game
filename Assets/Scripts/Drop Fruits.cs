// Name: Soren Nadjimi
// Teacher: Mr. Morrison
// Course: ICS4U1
// Due Date: Friday, January 19, 2024
using UnityEngine;
using TMPro;
using System.Collections.Generic; 

public class DropFruits : MonoBehaviour
{
    // Creates all of the gameObjects that need to be dropped/used, they will
    // be assigned in the unity editos.
    public GameObject CherryPrefab;
    public GameObject StrawberryPrefab;
    public GameObject GrapePrefab;
    public GameObject DekoponPrefab;
    public GameObject OrangePrefab;
    public GameObject CherryPreview;
    public GameObject StrawberryPreview;
    public GameObject GrapePreview;
    public GameObject DekoponPreview;
    public GameObject OrangePreview;
    public GameObject gameOverCanvas; 
    public TextMeshProUGUI button; 

    // uses a specific gameObject as a place to spawn the fruits.
    public GameObject spawnPoint;

    // ARRAYLIST that stores all of the fruits.
    private List<GameObject> fruits;
    // Array that stores all of the fruit previews.
    private GameObject[] fruitPreviews;
    // the current fruit that is being previewed.
    private GameObject currentPreview;
    // holds a number that will determine the index of the next fruit to be dropped. 
    private int nextFruitIndex = 0; 

    void Start()
    {
        // Activates the starting/ending screen at the beginning of the program.
        gameOverCanvas.SetActive(true); 
        // Fills the arrays/arraylists with all of the fruits/fruit previews.
        fruits = new List<GameObject> { CherryPrefab, StrawberryPrefab, GrapePrefab, DekoponPrefab, OrangePrefab };
        fruitPreviews = new GameObject[] { CherryPreview, StrawberryPreview, GrapePreview, DekoponPreview, OrangePreview };

        PrepareNextFruit();
    }

    void Update()
    {
        // The if statement will make sure that the mouse button has been clicked and the start/end screen is not
        // active before allowing the user to drop fruit.
        if (Input.GetMouseButtonDown(0) && !gameOverCanvas.activeInHierarchy)
        {
           
            // Drops the next fruit using the index as an argument.
            DropRandomFruit(nextFruitIndex);
            // Adds to the score.
            ScoreManager.Instance.AddScore(1); 

            PrepareNextFruit(); 
            
        }
    }

    // creates a method that will drop a random fruit when the user clicks.
    void DropRandomFruit(int nextFruitIndex)
    {
        // Spawns a clone of a random fruit.
        GameObject fruitClone = Instantiate(fruits[nextFruitIndex], spawnPoint.transform.position, Quaternion.identity);
        // Names the fruit with "_clone" at the end so I can easily identify and destroy them when I reset the game.
        fruitClone.name = fruits[nextFruitIndex].name + "_clone"; 

        // Creates a variable for the rigidbody2d of the fruit(physics).
        Rigidbody2D rb = fruitClone.GetComponent<Rigidbody2D>();
        // If there is a rigidbody2d on the object, the gravity will be set to 1, making it fall.
        if (rb != null)
        {
            rb.gravityScale = 1;
        }

        // If there is currently a preview, it will be destroyed by the program.
        if (currentPreview != null)
        {
            Destroy(currentPreview);
            // sets the preview to non-existent
            currentPreview = null;
        }
    }

    // method to prepare the next fruit that needs to be dropped, and display it so the user knows what fruit they are dropping.
    void PrepareNextFruit()
    {
        // randomly selects an index from the length of the fruits arraylist.
        nextFruitIndex = Random.Range(0, fruits.Count);

        // Will destroy the preview of the fruit if it currently exists.
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }

        // Instantiates the new preview where I have asked it to(in the bubble at the top right).
        Vector3 previewPosition = new Vector3(7.36f, 3.58f, 0f);
        currentPreview = Instantiate(fruitPreviews[nextFruitIndex], previewPosition, Quaternion.identity);
    }
}
