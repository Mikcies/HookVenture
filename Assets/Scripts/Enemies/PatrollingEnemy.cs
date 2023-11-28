using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    public Transform pointA;
    public Transform pointB;

    private Transform target;

    protected override void Start()
    {
        base.Start();
        target = pointA;
    }

    void Update()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
