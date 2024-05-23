using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppablePlatforms : MonoBehaviour
{
    private Collider2D collider;
    private bool playerplatform;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && playerplatform) 
        {
            collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }
    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.8f);
        collider.enabled = true;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
            playerplatform = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
            playerplatform = false;
    }
}
