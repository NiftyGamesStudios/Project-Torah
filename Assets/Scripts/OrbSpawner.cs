using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab;

    public float spawnInterval = 3f;
    public float orbSpeed = 5f;
    public float destroyDistance = 5f; // Distance from ground to destroy orb
    public ParticleSystem blastParticleSystem;

    private float timeSinceLastSpawn = 0f;

    public MMFeedbacks orbSpawningFeedback;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnAndMoveOrb();
            timeSinceLastSpawn = 0f;
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


