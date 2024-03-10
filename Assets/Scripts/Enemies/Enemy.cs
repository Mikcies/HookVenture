using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Transform player;
    [SerializeField] protected int MaxHp;
    protected int CurrHp;
    [SerializeField] protected float MoveSpeed;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        CurrHp = MaxHp;
    }

    void Update()
    {
        Move();
    }
    protected bool IsAlive()
    {
        bool _isAlive = CurrHp > 0;
        if (!_isAlive)
            HandleDeath();
        return _isAlive;
    }
    
    protected virtual void HandleDeath()
    {
        Collider2D collider = GetComponent<Collider2D>();

        if( collider != null)
        {
            collider.enabled = false;
        }
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.gray;
            spriteRenderer.sortingOrder = -1;
        }

    }
    protected abstract void Move();

    internal void TakeDamage()
    {
        CurrHp--;
        IsAlive();
    }
}
