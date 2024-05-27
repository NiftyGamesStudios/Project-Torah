using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    public ParticleSystem warningParticle;
    public ParticleSystem criticalParticle;

    public float delay = 2f;
    public AudioSource warningSound;
    public AudioSource fallSound;
    public float speed = 3.0f;
    private Transform player;
    public float fallSpeed = 5f;
    public MMFeedback screenShakeFeedback;


    Rigidbody2D rb;

    public float groundLevel = -10f;
    Vector3 gravity = new Vector3(0, -9.81f, 0); // Adjust -9.81f for desired gravity strength
    Vector3 velocity = Vector3.zero;

    bool fall = false;

    private void Start()
    {

            rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            return;
        }
         if (Vector2.Distance(transform.position,player.position)<= 10)
         {
             
             StartCoroutine(Fall());
         }
        if (fall)
        {
            velocity += gravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;

            // Check for ground collision (optional)
            if (transform.position.y < groundLevel)
            {
                transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
                velocity.y = 0; // Stop falling when ground is reached
                if(!criticalParticle.isPlaying) 
                    criticalParticle.Play();
                GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 2);

            }
        }
       
    }
    IEnumerator Fall()
    {
        warningParticle.Play();
        warningSound.Play();
        screenShakeFeedback.Play(transform.position);
        yield return new WaitForSeconds(delay);
        warningSound.Stop();
        warningParticle.Stop();
        screenShakeFeedback.Stop(transform.position);
        fallSound.Play();
        fall = true;

    }
   
}
