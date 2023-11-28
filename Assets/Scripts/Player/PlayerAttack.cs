using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform AttackPlase;
    [SerializeField]
    private float AttackRadius;
    [SerializeField]
    private LayerMask EnemyMask;

    void Start()
    {
        
    }
    void Update()
    {
        Attack();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPlase.position, AttackRadius);
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPlase.position, AttackRadius, EnemyMask);
            foreach (var collider in colliders)
            {
                Enemy enemy = collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Debug.Log("Enemy detected: " + enemy.gameObject.name);
                    Debug.Log("Hit");
                    enemy.TakeDamage();
                }
            }
        }
    }

}
