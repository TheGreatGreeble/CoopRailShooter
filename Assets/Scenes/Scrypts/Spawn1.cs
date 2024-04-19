using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // Reference to the object prefab you want to spawn
    public GameObject smallObject;
    public GameObject bigObject;
    private GameObject objectToSpawn;

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
            float randomX = Random.Range(-10f, 10f);
            float randomChoice = Random.Range(0,10);
            objectToSpawn = smallObject;
            if (randomChoice > 8){
                objectToSpawn = bigObject;
            }
            // Create a new position vector with the random Y coordinate
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, -15);

            // Instantiate a new object at the spawnPosition with no rotation
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, transform.rotation);
            MoveForward moveForward = spawnedObject.GetComponent<MoveForward>();

            moveForward.Activate(0.5f);


            // Wait for 1 second before spawning the next object
            yield return new WaitForSeconds(1f);
        }
    }
}
