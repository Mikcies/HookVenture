using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform AttackPlace;
    [SerializeField]
    private float AttackRadius;
    [SerializeField]
    private LayerMask EnemyMask;

    [SerializeField] AudioClip attackSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (attackSound != null)
        {
            audioSource.clip = attackSound;
        }
    }

    void Update() => Attack();
    private void OnDrawGizmos() => Gizmos.DrawWireSphere(AttackPlace.position, AttackRadius);

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (audioSource != null && attackSound != null)
            {
                audioSource.Play();
            }

            Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPlace.position, AttackRadius, EnemyMask);
            foreach (var collider in colliders)
            {
                if (collider.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage();
                }
                else if (collider.gameObject.TryGetComponent<Boss>(out var boss))
                {
                    boss.TakeDamage();
                }
                
            }
        }
    }
}
