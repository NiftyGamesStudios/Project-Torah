using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fishPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public float fishSpeed = 5f;
    public float minYSpawn = -2f;
    public float maxYSpawn = 2f;
    public float deactivateXPosition = -10f; // X position at which fish should deactivate
    public int poolSize = 10;

    private List<GameObject> fishPool = new List<GameObject>();
    private float timeSinceLastSpawn = 0f;

    private void Start()
    {
        InitializeFishPool();
      //  InvokeRepeating(nameof(SpawnFish), 0f, spawnInterval);
    }

    private void InitializeFishPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newFish = Instantiate(fishPrefab[Random.Range(0, fishPrefab.Length)]);
            newFish.SetActive(false);
            fishPool.Add(newFish);
        }
    }
    private void LateUpdate()
    {
        SpawnFish();
    }
    private void SpawnFish()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0f;

            // Find an inactive fish in the pool
            GameObject newFish = fishPool.Find(fish => !fish.activeSelf);
            if (newFish != null)
            {
                Vector3 spawnPosition = new Vector3(spawnPoint.position.x, Random.Range(minYSpawn, maxYSpawn), spawnPoint.position.z);
                
                newFish.SetActive(true);
                newFish.transform.position = spawnPosition;
                //Debug.Log("Fish Spawning at "+ newFish.transform.position);

                FishMovement fishMovement = newFish.GetComponent<FishMovement>();
                if (fishMovement != null)
                {
                    fishMovement.InitializeFish(fishSpeed, deactivateXPosition);
                }
            }
        }
    }
}
