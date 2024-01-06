using System.Collections;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnDistance = 20f;
    public float initialSpawnDelay = 1f;
    public float minSpawnDelay = 0.4f; // Minimum spawn delay
    public float spawnDelayDecreaseRate = 0.2f; // Amount to decrease the spawn delay

    void Start()
    {
        // Set the initial position of the spawner to (0, 0, 40)
        transform.position = new Vector3(0f, 0f, 40f);

        // Start spawning objects
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        float currentSpawnDelay = initialSpawnDelay;
        float timeSinceLastDecrease = 0f;

        while (true)
        {
            // Choose a random object from the array
            GameObject objectPrefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Instantiate the chosen object at the specified position
            GameObject newSpawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

            // Move the spawner along the Z-axis by the spawnDistance
            transform.position += new Vector3(0f, 0f, spawnDistance);

            // Automatically destroy the spawned object after 30 seconds
            Destroy(newSpawnedObject, 100f);

            // Wait for a short delay before the next spawn
            yield return new WaitForSeconds(currentSpawnDelay);

            // Decrease the spawn delay every 30 seconds
            timeSinceLastDecrease += currentSpawnDelay;
            if (timeSinceLastDecrease >= 30f)
            {
                currentSpawnDelay = Mathf.Max(minSpawnDelay, currentSpawnDelay - spawnDelayDecreaseRate);
                timeSinceLastDecrease = 0f;
            }
        }
    }
}
