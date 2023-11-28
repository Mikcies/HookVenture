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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
    }
    private void CheckIsGrounded()
    {
        var hit = Physics2D.Raycast(Ray.position, Vector2.down, 0.5f, floorLayerMask);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    public void Move()
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                yMove = Jump;
            }
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
}

    