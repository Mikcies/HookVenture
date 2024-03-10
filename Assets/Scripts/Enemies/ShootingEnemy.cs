using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private float ShootingRange;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletStart;
    [SerializeField] private float FireRate;
    [SerializeField] private float NextFire;

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        if(IsAlive())
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (DistanceFromPlayer <= ShootingRange && NextFire < Time.time)
        {
            Instantiate(bullet, bulletStart.transform.position, transform.rotation);
            NextFire = Time.time + FireRate;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
        //Gizmos.DrawWireSphere(transform.transform.position, Site);
    }

    protected override void Move()
    {

    }
}
