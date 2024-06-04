using UnityEngine;

public class CannalBoss : Boss
{
    [SerializeField] private Transform placeOfOrigin;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float intervalBetweenShots;
    [SerializeField] private float minPos;
    [SerializeField] private float maxPos;
    private Transform bulletSpawnPoint;
    private float timeSinceLastShot;
    internal static bool CannalBossAlive = true;

    protected new void Start()
    {
        base.Start();
        bulletSpawnPoint = placeOfOrigin;
    }

    protected new void Update()
    {
        base.Update();

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= intervalBetweenShots && IsAlive())
        {
            ShootBullet();
            timeSinceLastShot = 0f;
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            Vector2 direction = player.position - bulletSpawnPoint.position;
            direction.Normalize();

            bulletRb.velocity = direction * bulletSpeed;
        }
    }

    protected override void Attack()
    {
        Vector2 randomPosition = new Vector2(bulletSpawnPoint.position.x, Random.Range(minPos, maxPos));
        bulletSpawnPoint.position = randomPosition;
    }
    protected override void HandleDeath()
    {
        Collider2D collider = GetComponent<Collider2D>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        if (renderer != null)
        {
            renderer.color = Color.gray;
            renderer.sortingOrder = -1;
        }
        CannalBossAlive = false;
    }
}
