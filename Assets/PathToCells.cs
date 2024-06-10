using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PathToCells : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;
    [SerializeField]
    float MoveSpeed;
    private Transform target;


    [SerializeField] SpriteRenderer leverRenderer;
    [SerializeField] Canvas leverCanvas;
    [SerializeField] TMP_Text text;

    bool StandingIn = false;
    private bool isActivated = false;
    

    void Start()
    {
        leverCanvas.enabled = false;
        target = pointA;
        Debug.Log(PlayerPrefs.GetInt("CannalBossAlive"));
    }

    void Update()
    {
        if (StandingIn && Input.GetKeyDown(KeyCode.E) && !isActivated)
        {
            ActivateLever();
        }
        if(isActivated == true)
        {
            PlatformMove();
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverCanvas.enabled = true;
            StandingIn = true;
            TextChange();
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverCanvas.enabled = false;
            StandingIn = false;
        }
    }
    private void ActivateLever()
    {
        if (!CannalBoss.CannalBossAlive)
        {
            isActivated = true;
            leverRenderer.flipX = !leverRenderer.flipX;
        }
        
    }
    private void PlatformMove()
    {
        float distance = Vector2.Distance(platform.transform.position, target.position);

        platform.transform.position = Vector2.MoveTowards(platform.transform.position, target.position, MoveSpeed * Time.deltaTime);

        if (distance < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }


    private void TextChange()
    {
        if(CannalBoss.CannalBossAlive)
        {
            text.text = "You need to kill boss in the sewers";
        }
        else
        {
            text.text = "You can pass to cells";
        }
    }
}
