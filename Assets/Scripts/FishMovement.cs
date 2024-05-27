using UnityEditor.Build.Content;
using UnityEngine;

public enum FishType
{
    Friendly,
    Pufferfish,
    Piranha
}
public class FishMovement : MonoBehaviour
{
    private float speed;
    private float deactivateXPosition;
    public FishType fishType;
    public float contactDistance = 0.5f; // Adjust as needed
    [Header("Piranha")]
    private Transform player;
    public float followRange = 10f;

    [Header("PufferFish")]
    public GameObject blastEffect;
 

    public void InitializeFish(float fishSpeed, float deactivateX)
    {
        speed = fishSpeed;
        deactivateXPosition = deactivateX;
        
    }

    private void Update()
    {
        MoveFish();

        if (player != null)
        {
            switch (fishType)
            {
                case FishType.Friendly:
                    // Do nothing when player is near
                    break;
                case FishType.Pufferfish:
                    // Blast when near player
                    BlastWhenNearPlayer();
                    break;
                case FishType.Piranha:
                    // Follow player and damage on touch
                    FollowPlayerAndDamage();
                    break;
            }
        }
        else
            player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    private void MoveFish()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if fish should be deactivated
        if (transform.position.x <= deactivateXPosition)
        {
            gameObject.SetActive(false);
        }
    }
    private bool isParticleSpawned = true;
    private void BlastWhenNearPlayer()
    {
        // Check if player is near
        //float blastDistance = 2f; // Adjust as needed
        Debug.Log(this.gameObject.name+" Distance : " + Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) <= contactDistance)
        {
            // Perform blast action
            // For example:
            if(isParticleSpawned)
            {
                Debug.Log("Pufferfish blasts!");
                GameObject blastParticle = Instantiate(blastEffect, transform.position, Quaternion.identity);
                Destroy(blastParticle, 1);
                isParticleSpawned=false;
                gameObject.SetActive(false);
            }
            

        }
    }
   
    private void FollowPlayerAndDamage()
    {
        float distance = Vector2.Distance(transform.position,player.transform.position);
        if(distance > followRange)
            MoveFish();
        else
        {
            // Look at player
            transform.LookAt(player.transform);

            // Follow player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            // Check if player is in contact
            
            if (Vector3.Distance(transform.position, player.transform.position) <= contactDistance)
            {
                // Damage player
                // For example:

            }
        }
      
    }

    private void OnDisable()
    {
        // Reset fish position when deactivated
        transform.position = Vector3.zero;
    }
}
