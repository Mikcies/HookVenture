using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasingEnemy : Enemy
{
    [SerializeField] private float Site;
    Vector2 originalPlace;
    protected override void Start()
    {
       base.Start();
       originalPlace = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (DistanceFromPlayer < Site)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPlace, MoveSpeed * Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Site);
    }
}
