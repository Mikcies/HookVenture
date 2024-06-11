using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackImage;
    public Transform AttackPlace;
    public float AttackRadius;
    public LayerMask EnemyMask;
    public AudioSource audioSource;
    public AudioClip attackSound;

    private float timer = 0f;

    private void Start()
    {
        AttackImage.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        AttackImage.SetActive(true);
        StartCoroutine(HideAttackImageAfterDelay(0.1f));

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

    private IEnumerator HideAttackImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AttackImage.SetActive(false);
    }
}
