using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // Reference to the object prefab you want to spawn
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine for spawning objects
        StartCoroutine(SpawnObjectEverySecond());
    }

    IEnumerator SpawnObjectEverySecond()
    {
        while (true)
        {
            // Generate a random Y coordinate between 1 and 10
            float randomX = Random.Range(-5f, 5f);

            // Create a new position vector with the random Y coordinate
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, -5);

            // Instantiate a new object at the spawnPosition with no rotation
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Wait for 1 second before spawning the next object
            yield return new WaitForSeconds(1f);
        }
    }
}
