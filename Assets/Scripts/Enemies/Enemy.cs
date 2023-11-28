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
    
    protected void HandleDeath()
    {
        rb.isKinematic = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.gray;
            spriteRenderer.sortingOrder = -1;
        }
        else
        {
            Debug.LogError("SpriteRenderer component is null in HandleDeath");
        }
    }
    protected abstract void Move();

    public void TakeDamage()
    {
        CurrHp--;
        IsAlive();
    }
}
