using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperController : MonoBehaviour
{
    public float speed;
    public bool enemyPatrol;
    private bool enemyTurn;
    public Rigidbody2D rb;
    public Transform groundCheckpPosition;
    public LayerMask groundLayer;
    public Collider2D bodycollider;

    private void Start()
    {
        enemyPatrol = true;
    }
    private void Update()
    {
        if(enemyPatrol)
        {
          Patrol();
        }
    }
    private void FixedUpdate()
    {
        if(enemyPatrol)
        {
            enemyTurn = !Physics2D.OverlapCircle(groundCheckpPosition.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (enemyTurn || bodycollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        enemyPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        enemyPatrol = true;
    }
}
