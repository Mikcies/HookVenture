using UnityEditor;
using UnityEngine;

public class CaveBoss : Boss
{
    [SerializeField] private Transform PlaceA;
    [SerializeField] private Transform PlaceB;
    [SerializeField] private Transform PlaceC;
    [SerializeField] private Transform PlaceD;

    [SerializeField] private Transform ShootingPlace;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float timeSinceLastShot;
    [SerializeField] private float intervalBetweenShots = 5f;

    internal static bool CaveBossAlive = true;



    protected void Update()
    {
        base.Update();
    }
    internal override void TakeDamage()
    {
        TeleportRandomly();
        base.TakeDamage();
    }

    private void TeleportRandomly()
    {
        Transform[] transforms = new Transform[] { PlaceA, PlaceB, PlaceC };
        Transform randomTransform = transforms[Random.Range(0, transforms.Length)];
        transform.position = randomTransform.position;
    }

    protected override void Attack()
    {
        timeSinceLastShot += Time.deltaTime;
        if(timeSinceLastShot >= intervalBetweenShots && CurrHp > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, ShootingPlace.position, ShootingPlace.rotation);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector2 direction = (player.transform.position - bullet.transform.position).normalized;
                Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
                bulletRB.velocity = direction;
                timeSinceLastShot = 0f;
            }
        }
        
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
        CaveBossAlive = false;
    }
}
