using System.Collections;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnDistance = 20f;
    public float spawnDelay = 1f;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Choose a random object from the array
            GameObject objectPrefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Instantiate the chosen object at the specified position
            GameObject newSpawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

            // Move the spawner along the Z-axis by the spawnDistance
            transform.position += new Vector3(0f, 0f, spawnDistance);

            // Automatically destroy the spawned object after 5 seconds
            Destroy(newSpawnedObject, 5f);

            // Wait for a short delay before the next spawn
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
