using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // The prefab to spawn
    public float spawnInterval = 2f; // Time between spawns
    public float spawnHeightMin = -3f; // Minimum Y position for spawning
    public float spawnHeightMax = 3f; // Maximum Y position for spawning
    public float distanceFromPlayer = 40;

    public bool canThrow = false;

    public Transform player;
    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void Update()
    {
        if (canThrow)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }

            // Update the spawner's position to maintain the fixed distance from the player
            else
            {
                Vector3 newPosition = transform.position;
                newPosition.x = player.position.x + distanceFromPlayer;
                transform.position = newPosition;
            }
        }
       
    }
    void SpawnObject()
    {
        if (canThrow)
        {
            float spawnY = Random.Range(spawnHeightMin, spawnHeightMax);
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, 0);
            Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], spawnPosition, Quaternion.identity);
        }
        
    }
}
