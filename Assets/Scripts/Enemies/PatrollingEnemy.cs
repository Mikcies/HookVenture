using UnityEngine;

public class PatrollingEnemy : Enemy
{
    [SerializeField] private Transform BodA;
    [SerializeField] private Transform BodB;
    [SerializeField] private float speed = 2.0f;
    private SpriteRenderer spriteRenderer;

    private Vector3 targetPosition;
    private Vector3 direction;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

        targetPosition = BodA.position;
    }

    void Update()
    {
        if (IsAlive() && CurrHp > 0)
        {
            Move();
        }
    }
    protected override void Move()
    {
        Vector3 previousPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        direction = transform.position - previousPosition;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SwitchTarget();
        }

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void SwitchTarget()
    {
        if (targetPosition == BodA.position)
        {
            targetPosition = BodB.position;
        }
        else
        {
            targetPosition = BodA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SwitchTarget();
        }
    }
}