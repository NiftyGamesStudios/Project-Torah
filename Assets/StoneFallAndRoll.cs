using UnityEngine;

public class StoneFallAndRoll : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float rollSpeed = 10f;
    public float stopPositionX = 715f;

    public Transform player;
    public LayerMask obstacleLayer;


    private Rigidbody2D rb;
    private bool hasFallen = false;
    private bool isRolling = false;

    public LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasFallen)
        {
            Fall();
        }
        else if (isRolling)
        {
            Roll();
        }
    }

    void Fall()
    {
        rb.velocity = new Vector2(0, -fallSpeed);
    }

    void Roll()
    {

        if (transform.position.x >= stopPositionX)
        {
            // Stop the stone when it reaches the fixed position
            rb.velocity = Vector2.zero;
            isRolling = false;
        }
        else
        {
            rb.velocity = new Vector2(Vector2.right.x * rollSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
         hasFallen = true;
         isRolling = true;
    }
}
