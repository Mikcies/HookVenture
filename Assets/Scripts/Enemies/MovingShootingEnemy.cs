using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShootingEnemy : Enemy
{
    [SerializeField] private float Site;
    private Vector2 originalPlace;
    [SerializeField] private float ShootingRange;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletStart;
    [SerializeField] private float FireRate;
    [SerializeField] private float NextFire;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    protected override void Move()
    {
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (DistanceFromPlayer < Site && DistanceFromPlayer > ShootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, MoveSpeed * Time.deltaTime);

        }
        else if (DistanceFromPlayer <= ShootingRange && NextFire < Time.time)
        {
            Shoot();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPlace, MoveSpeed * Time.deltaTime);
        }
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
}
