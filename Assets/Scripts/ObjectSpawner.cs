using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] fallingObjects; // Array of prefabs (good and bad images)
    public float spawnInterval = 1f; // Time interval between spawns
    public float xRange = 8f; // Horizontal range for spawning

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval); // Start spawning objects
    }

    private void SpawnObject()
    {
        // Pick a random prefab from the array
        GameObject objectToSpawn = fallingObjects[Random.Range(0, fallingObjects.Length)];

        // Randomize spawn position within the specified xRange
        Vector2 spawnPosition = new Vector2(Random.Range(-xRange, xRange), 6f); // Adjust y value as needed

        // Instantiate the object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
