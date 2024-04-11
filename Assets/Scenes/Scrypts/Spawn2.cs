using UnityEngine;
using System.Collections;

public class Spawner2 : MonoBehaviour
{
    // Reference to the object prefab you want to spawn
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine for spawning objects
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            // Generate a random Y coordinate between 1 and 10
            float randomZ = Random.Range(-5f, 5f);

            // Create a new position vector with the random Y coordinate
            Vector3 spawnPosition = new Vector3(-5, transform.position.y, randomZ);

            // Instantiate a new object at the spawnPosition with no rotation
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Wait for 1 second before spawning the next object
            yield return new WaitForSeconds(1f);
        }
    }
}
