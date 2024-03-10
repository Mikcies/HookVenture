using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HPControll : MonoBehaviour
{
    [SerializeField]
    private int MaxHP;
    [SerializeField]
    private int CurrHP;

    [SerializeField]
    Image[] Hearts;
    [SerializeField]
    Sprite UnhittedHealth;
    [SerializeField]
    Sprite HittedHealth;


    private bool isHitCooldown = false;
    private float hitCooldownTimer = 0f;
    public float maxHitCooldownTime = 1.0f;

    private Vector2 playerDeathPosition;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Transform setPlayerDeath;
    void Start()
    {
        CurrHP = MaxHP;
    }
    void Update()
    {
        GenerateHealthBar();
        IFrames();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Boss"))
        {
            IsHit();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            IsHit();  
        }
    }
    private void IsHit()
    {
        if (CurrHP > 0 && !isHitCooldown)
        {
            CurrHP--;
            isHitCooldown = true;
            hitCooldownTimer = maxHitCooldownTime;

            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (CurrHP <= 0)
        {
            playerDeathPosition = transform.position;
            Instantiate(prefab, playerDeathPosition, Quaternion.identity);
            CurrHP = 1;
            transform.position = setPlayerDeath.position;
        }
    }
    private void GenerateHealthBar()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < CurrHP)
            {
                Hearts[i].sprite = UnhittedHealth;
            }
            else
            {
                Hearts[i].sprite = HittedHealth;

            }
            if (i < MaxHP)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }
    private void IFrames()
    {
        if (isHitCooldown)
        {
            hitCooldownTimer -= Time.deltaTime;

            if (hitCooldownTimer <= 0f)
            {
                isHitCooldown = false;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
