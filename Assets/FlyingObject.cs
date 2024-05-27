using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed at which the object moves to the left
    public float rotationSpeed = 200f; // Speed of rotation
    public GameObject breakEffect; // Effect to instantiate when the object breaks

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = rotationSpeed; // Set initial rotation
    }

    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Break();
    }

    void Break()
    {
        // Instantiate the break effect if any
        if (breakEffect != null)
        {
            Instantiate(breakEffect, transform.position, transform.rotation);
        }

        // Destroy the object
        Destroy(gameObject);
    }
}
