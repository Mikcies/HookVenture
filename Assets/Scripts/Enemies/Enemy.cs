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
    [SerializeField]
    GameObject CoinPrefab;
    private bool coinsDropped = false;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        CurrHp = MaxHp;
    }

    protected void Update()
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
        if (!coinsDropped)
        {
            DropCoins();
            coinsDropped = true;
        }

    }
    protected abstract void Move();

    internal void TakeDamage()
    {
        CurrHp--;
        IsAlive();
    }
    void DropCoins()
    {
        int numberOfCoins = Random.Range(1, 5);

        for (int i = 0; i < numberOfCoins; i++)
        {
            float randomOffsetX = Random.Range(-4f, 4f);

            Vector3 spawnPosition = transform.position + new Vector3(randomOffsetX, 0f, 0f);

            Instantiate(CoinPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
