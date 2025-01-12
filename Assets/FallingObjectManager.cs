using System.Collections;
using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Add AIText and HumanText prefabs here
    public float spawnInterval = 5f; // Adjust this to control the spawn rate
    public float xRange = 8f; // Adjust as per your scene
    public float fallSpeed = 0.001f; // Extremely slow fall speed

    void Start()
    {
        // Ensure consistent time scale for the whole game
        Time.timeScale = 1f; // Can be adjusted if needed for overall game speed
        InvokeRepeating("SpawnObject", 0f, spawnInterval); // Consistent spawn interval
    }

    void SpawnObject()
    {
        if (objectsToSpawn == null || objectsToSpawn.Length == 0)
        {
            Debug.LogError("No objects assigned to spawn. Please populate the objectsToSpawn array.");
            return;
        }

        // Get the camera height (to spawn objects outside the visible screen)
        float screenHeight = Camera.main.orthographicSize * 2; // Full height of the camera view in world units
        float randomX = Random.Range(-xRange, xRange);

        // Set the spawn position above the screen (use the screenHeight to set a high Y value)
        Vector3 spawnPosition = new Vector3(randomX, Camera.main.orthographicSize + 1, 0); // +1 to ensure it starts slightly above

        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        // Instantiate the object and store it in a variable
        GameObject fallingObject = Instantiate(objectsToSpawn[randomIndex], spawnPosition, Quaternion.identity);

        // Initialize fall speed to zero
        float currentFallSpeed = 0f;

        // Gradually increase fall speed over a few frames (adjust lerpDuration as needed)
        float lerpDuration = 0.5f; // Adjust this value to control the smoothing duration
        for (int i = 0; i < Mathf.FloorToInt(lerpDuration * 60f); i++) // Simulate Update calls for lerpDuration seconds
        {
            currentFallSpeed = Mathf.Lerp(currentFallSpeed, fallSpeed, Time.deltaTime / lerpDuration);
        }

        // Ensure the falling speed is passed to the FallingObjectScript
        FallingObjectScript fallingScript = fallingObject.GetComponent<FallingObjectScript>();
        if (fallingScript != null)
        {
            fallingScript.fallSpeed = currentFallSpeed;
        }
        else
        {
            Debug.LogWarning("No FallingObjectScript found on " + fallingObject.name);
        }
    }
}
