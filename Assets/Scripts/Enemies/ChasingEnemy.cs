using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasingEnemy : Enemy
{
    [SerializeField] private float Site;
    Vector2 originalPlace;
    private SpriteRenderer spriteRenderer;
    protected override void Start()
    {
       base.Start();
       originalPlace = transform.position;
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive() && CurrHp > 0)
        {
            Move();
        }
    }

    protected override void Move()
    {
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        float distanceFromPlayer = Vector2.Distance(playerPosition, transform.position);

        if (distanceFromPlayer < Site)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            FlipSprite(playerPosition.x - transform.position.x);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPlace, MoveSpeed * Time.deltaTime);
            FlipSprite(originalPlace.x - transform.position.x);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Site);
    }
    private void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
