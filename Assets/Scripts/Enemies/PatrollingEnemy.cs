using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;

    private Transform target;
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        target = pointA;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(IsAlive())
        {
            Move();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = (target == pointA) ? pointB : pointA;
            Debug.Log(target);
        }
    }

    protected override void Move()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
