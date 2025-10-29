using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform upperSpawnLimit;
    public Transform lowerSpawnLimit;

    public float spawnRateMax;
    public float spawnRateMin;
    public float spawnRate;
    private float spawnDelay;
    private Vector3 spawnPos;

    public ItemCollection itemLibrary;


    public bool groupSpawner;
    public GameObject enemyPrefab;
    public Transform enemyTarget;
    private void Update()
    {
        spawnConditionals();
    }

    protected virtual void spawnConditionals()
    {
        
        spawnDelay += Time.deltaTime; // Increase spawn delay based on time, not frame count

        // Calculate the delay between spawns based on spawnRate (number of objects per second)
        float timeBetweenSpawns = 1f / spawnRate;

        // Spawn an object when the time exceeds the time between spawns
        if (spawnDelay >= timeBetweenSpawns)
        {
            spawnObjects();
            spawnDelay = 0f; // Reset the spawn delay after spawning
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    protected virtual void spawnObjects()
    {
        // Random scalar between 0 and 1 for each axis
        float scalarX = Random.Range(0f, 1f);
        float scalarY = Random.Range(0f, 1f);
        float scalarZ = Random.Range(0f, 1f); // Add Z-axis randomization

        // Calculate the spawn position based on the scalar and limits for each axis
        float modX = Mathf.Lerp(lowerSpawnLimit.position.x, upperSpawnLimit.position.x, scalarX);
        float modY = Mathf.Lerp(lowerSpawnLimit.position.y, upperSpawnLimit.position.y, scalarY);
        float modZ = Mathf.Lerp(lowerSpawnLimit.position.z, upperSpawnLimit.position.z, scalarZ); // Add Z-axis Lerp

        spawnPos = new Vector3(modX, modY, modZ); // Set the spawn position in 3D

        // Debugging output to ensure position calculations are correct
        //Debug.Log("Spawn Position: " + spawnPos);

        // Instantiate the object at the randomized position

        //Instantiate(itemLibrary.SelectRandomItem(), spawnPos, Quaternion.identity);

        if (groupSpawner)
        {
            Instantiate(itemLibrary.SelectRandomItem(), spawnPos, Quaternion.identity);
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<LerpMovement>().target = enemyTarget;
        }
    }


}

