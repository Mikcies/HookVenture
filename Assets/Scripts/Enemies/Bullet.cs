using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    [SerializeField]
    float BulletSpeed;
    Rigidbody2D bulletRB;
    
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 movedir = (target.transform.position - transform.position).normalized * BulletSpeed;
        bulletRB.velocity = new Vector2(movedir.x, movedir.y);
        Destroy(this.gameObject, 1);
    }
}
