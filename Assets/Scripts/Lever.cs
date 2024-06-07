using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Lever : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] SpriteRenderer leverRenderer;
    private Collider2D doorCollider;
    private SpriteRenderer doorSpriteRenderer;

    [SerializeField] Canvas leverCanvas;
    [SerializeField] TMP_Text text;

    bool StandingIn = false;
    private bool isActivated = false;
    [SerializeField]
    string message;

    void Start()
    {
        doorCollider = door.GetComponent<Collider2D>();
        doorSpriteRenderer = door.GetComponent<SpriteRenderer>();
        leverCanvas.enabled = false;
    }

    void Update()
    {
        if (StandingIn && Input.GetKeyDown(KeyCode.E) && !isActivated)
        {
            ActivateLever();
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverCanvas.enabled = true;
            text.text = message;
            StandingIn = true;
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
        isActivated = true;
        leverRenderer.flipY = !leverRenderer.flipY;
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }

        if (doorSpriteRenderer != null)
        {
            doorSpriteRenderer.color = Color.gray;
        }
    }
}
