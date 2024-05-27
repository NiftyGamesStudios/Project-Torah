using DG.Tweening;
using UnityEngine;

public class StoneThrower : MonoBehaviour
{
    public GameObject[] stoneObjects;
    public float forceMaxMagnitude = 10f;
    public float forceMinMagnitude = 10f;
    public float minHeight = 0.1f; // Minimum height before stopping force

    public float fadeOutDelay = 3f;
    public float fadeOutDuration = 1f;

    public ParticleSystem smokePS;

    bool stoneThrowed = false;

    void Start()
    {

    }

    public void ThrowStones()
    {
        foreach (GameObject stone in stoneObjects)
        {
            Rigidbody rb = stone.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                float forceMagnitude = Random.Range(forceMinMagnitude, forceMaxMagnitude);
                Vector3 throwDirection = transform.right; // Change this if you want a different throw direction
                rb.AddForce(throwDirection * forceMagnitude, ForceMode.Impulse);
                smokePS.Play();
                stoneThrowed = true;
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found on stone object: " + stone.name);
            }
        }
    }

    void Update()
    {
        if(stoneThrowed) 
            CheckMinHeight();
    }

    void CheckMinHeight()
    {
        foreach (GameObject stone in stoneObjects)
        {
            if (stone.transform.position.y < minHeight)
            {
                Rigidbody rb = stone.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero; // Stop the stone's movement
                    rb.angularVelocity = Vector3.zero; // Stop the stone's rotation
                    rb.isKinematic = true; // Make the stone kinematic to stop physics interactions
                    FadeOutStone(stone);
                }
            }
        }
    }
    void FadeOutStone(GameObject stone)
    {
        DOTween.Sequence()
            .AppendInterval(fadeOutDelay)
            .Append(stone.transform.DOScale(0, fadeOutDuration))
            .OnComplete(() => Destroy(stone.gameObject));
    }
}
