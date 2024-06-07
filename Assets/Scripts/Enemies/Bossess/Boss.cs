using System.Diagnostics;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    protected Transform player;
    [SerializeField] protected int MaxHp;
    protected int CurrHp;
    [SerializeField] protected float MoveSpeed;
    protected Rigidbody2D rb;
    [SerializeField] SpriteRenderer renderer;
    protected void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        CurrHp = MaxHp;
    }
    protected void Update()
    {
        Attack();
    }
    protected abstract void Attack();

    internal virtual void TakeDamage()
    {
        CurrHp--;
        IsAlive();
    }
    internal bool IsAlive()
    {
        bool isAlive = CurrHp > 0;
        if (!isAlive)
            HandleDeath();
        return isAlive;
    }
    protected virtual void HandleDeath()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        if (renderer != null)
        {
            renderer.color = Color.gray;
            renderer.sortingOrder = -1;
        }
    }
}
