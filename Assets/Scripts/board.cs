using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    bool StandingIn = false;
    [SerializeField] Canvas boardCanvas;

    // Start is called before the first frame update
    void Start()
    {
        boardCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        boardCanvas.enabled = StandingIn;

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
            StandingIn = false;
        }
    }
}
