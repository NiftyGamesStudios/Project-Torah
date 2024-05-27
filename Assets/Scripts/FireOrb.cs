using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrb : MonoBehaviour
{
   // public Transform playerTransform;
    public float orbSpeed = 5f;
    private Vector3 direction;
    private float orbRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
       // playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
       // direction = (playerTransform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      //  if (playerTransform == null)        
        //    return;
        
      
        
    }
    private void CollisionDetect()
    {

        // Cast a sphere from the orb's position downwards
        if (Physics2D.CircleCast(transform.position, orbRadius, Vector2.down))
        {
            Debug.Log("Collision detected between orb and floor!");
            // Add your logic here for handling the collision
        }
    }
}
