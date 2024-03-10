using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;
    [SerializeField]
    float MoveSpeed;

    private Transform target;

    private void Start()
    {
        target = pointA;
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
