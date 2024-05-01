using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HPControll : MonoBehaviour
{
    [SerializeField]
    private int MaxHP;
    [SerializeField]
    internal static int CurrHP;

    internal int Hearthpieces = 0;

    [SerializeField]
    Image[] Hearts;
    [SerializeField]
    Sprite UnhittedHealth;
    [SerializeField]
    Sprite HittedHealth;


    private bool isHitCooldown = false;
    private float hitCooldownTimer = 0f;
    [SerializeField]
    float maxHitCooldownTime = 1.0f;

    private Vector2 playerDeathPosition;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Transform setPlayerDeath;
    void Start()
    {
        MaxHP = 5;
        CurrHP = MaxHP;
    }
    void Update()
    {
        GenerateHealthBar();
        IFrames();
        IncreaseMaxHealth();
    }
    private void OnEnable()
    {
    }
    void sceneLoaded(string scene, LoadSceneMode mode)
    {
        scene = bonfire.currentSceneName.ToString();
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
            Collect.CoinAmount = 0;
            SetPlayerToBonfire();
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

    private void IncreaseMaxHealth()
    {
        if(Hearthpieces == 3)
        {
            MaxHP++;
        }
    }
    private void SetPlayerToBonfire()
    {
        StartCoroutine(LoadSceneAsyncAndSetPlayerPosition());
    }

    private IEnumerator LoadSceneAsyncAndSetPlayerPosition()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(bonfire.currentSceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return null;

        transform.position = bonfire.playerPosition;
    }




}
