using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField]
    private float Walkspeed;

    [SerializeField]
    private float Jump;

    [SerializeField]
    private Transform Ray;

    [SerializeField]
    private LayerMask floorLayerMask;

    private bool isGrounded = false;
    [SerializeField]
    internal static bool SecondJump = false;
    private bool hasDoubleJumped = false;

    [SerializeField]    
    internal static bool Dash = false;
    bool canDash = true;
    bool isDashing;
    [SerializeField]
    float dashspeed;
    [SerializeField]
    float dashingTime;
    float dashCD = 1f;
    [SerializeField]
    TrailRenderer tr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        Move();
    }
    private void Move()
    {
        isGrounded = (Physics2D.Raycast(Ray.position, Vector2.down, 0.5f, floorLayerMask).collider != null);

        float xMove = 0;
        float yMove = rb.velocity.y;

        if (Input.GetKey(KeyCode.D))
        {
            xMove = Walkspeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xMove = -Walkspeed;
        }

        if (isGrounded)
        {
            hasDoubleJumped = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                yMove = Jump;
            }
            else if (!hasDoubleJumped && SecondJump)
            {
                yMove = Jump;
                hasDoubleJumped = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash && Dash)
        {
            StartCoroutine(PlayerDash());
        }
        
        if (xMove > 0)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        }
        else if (xMove < 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);        
        }

        rb.velocity = new Vector2(xMove, yMove);
        
    }
    private IEnumerator PlayerDash()
    {
        canDash = false;
        isDashing = true;
        float Gravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashspeed, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = Gravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
}

    