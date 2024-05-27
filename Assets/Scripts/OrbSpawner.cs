using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab;

    public float minSpawnInterval = 3f;
    public float maxSpawnInterval = 3f;

    public float orbSpeed = 5f;
    public float destroyDistance = 5f; // Distance from ground to destroy orb
    public ParticleSystem blastParticleSystem;

    private float timeSinceLastSpawn = 0f;

    public MMFeedbacks orbSpawningFeedback;

    void Start()
    {
        StartCoroutine(SpawnOrbs());
    }

    private IEnumerator SpawnOrbs()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
            SpawnAndMoveOrb();
        }
    }

    private void SpawnAndMoveOrb()
    {
        GameObject newOrb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
        orbSpawningFeedback?.PlayFeedbacks();

        StartCoroutine(MoveAndDestroyOrb(newOrb));
    }

    private IEnumerator MoveAndDestroyOrb(GameObject orb)
    {
        if (orb != null)
        {
            while (orb.transform.position.y > destroyDistance)
            {
                orb.transform.Translate(Vector3.down * orbSpeed * Time.deltaTime);
                yield return null;
            }

            GameObject ps = Instantiate(blastParticleSystem, orb.transform.position, Quaternion.identity).gameObject;
            ps.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            Destroy(orb);
            Destroy(ps, 2);
        }
    }
}
