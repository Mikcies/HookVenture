using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject door;

    private Collider2D doorCollider;
    private SpriteRenderer doorSpriteRenderer;

    bool StandingIn = false;
    private bool isActivated = false;

    void Start()
    {
        doorCollider = door.GetComponent<Collider2D>();
        doorSpriteRenderer = door.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Debug.Log(StandingIn);
        if (StandingIn && Input.GetKeyDown(KeyCode.E) && !isActivated)
        {
            ActivateLever();
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StandingIn = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StandingIn = true;
        }
    }
    private void ActivateLever()
    {
        isActivated = true;

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
