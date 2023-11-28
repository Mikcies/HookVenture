using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private float Site;
    private Vector2 originalPlace;
    [SerializeField]  private float ShootingRange;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletStart;
    [SerializeField] private float FireRate;
    [SerializeField] private float NextFire;
    void Start()
    {
        base.Start();
        originalPlace = transform.position;
    }
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (DistanceFromPlayer <= ShootingRange && NextFire < Time.time)
        {
            Instantiate(bullet, bulletStart.transform.position, Quaternion.identity);
            NextFire = Time.time + FireRate;
        }
    }
    protected override void Move()
    {
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Site);
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
