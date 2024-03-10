using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    
    void Start()
    {
    }

    void Update()
    {
    }
    protected override void Move()
    {
    }
    protected override void HandleDeath()
    {
       Destroy(gameObject);

    }
}
