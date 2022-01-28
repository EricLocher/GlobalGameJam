using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static LayerMask ignoreLayer;

    Rigidbody2D rb;
    float speed = 5;
    float jumpForce = 7;

    bool isGrounded = false;
    float coyoteTime = 0.1f;
    float coyoteCounter;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    private void Start()
    { 
        ignoreLayer |= (1 << LayerMask.NameToLayer("Ground"));
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {        
        Move();
        Jump();
        GroundChecker();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if (isGrounded) { coyoteCounter = coyoteTime; }
        else { coyoteCounter -= Time.deltaTime; }

        if (coyoteCounter >0f && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void GroundChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, ignoreLayer);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
            isGrounded = false;
    }
}
