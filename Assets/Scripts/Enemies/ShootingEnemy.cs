using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{

    float timer;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletpos;

    
    protected void Update()
    {
        base.Update();
        float dis = Vector2.Distance(transform.position, player.transform.position);
        timer += Time.deltaTime;
        if (IsAlive())
        {
            if (dis < 10)
            {
                if (timer > 1.5f)
                {
                    timer = 0;
                    Shoot();
                }

            }
        }
        
        
    }
    void Shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }

    protected override void Move()
    {
    }
}
