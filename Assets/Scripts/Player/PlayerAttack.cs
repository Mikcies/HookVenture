using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform AttackPlase;
    [SerializeField]
    private float AttackRadius;
    [SerializeField]
    private LayerMask EnemyMask;
    void Update() => Attack();
    private void OnDrawGizmos() => Gizmos.DrawWireSphere(AttackPlase.position, AttackRadius);
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPlase.position, AttackRadius, EnemyMask);
            foreach (var collider in colliders)
            {
                Enemy enemy;
                Boss boss;
                Ghost ghost;
                if (collider.gameObject.TryGetComponent(out enemy))
                {
                    enemy.TakeDamage();
                }
                else if (collider.gameObject.TryGetComponent(out boss))
                {
                    boss.TakeDamage();
                }
                else if (collider.gameObject.TryGetComponent(out ghost))
                {
                    ghost.TakeDamage();
                }
            }
        }
    }
}