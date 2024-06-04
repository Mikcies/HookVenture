using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShootGrapple : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] DistanceJoint2D Distancejoint;
    Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] Transform LinePosition;
    [SerializeField] bool isGrappling;
    [SerializeField] LayerMask floorLayerMask;
    [SerializeField] private Transform Ray;

    [SerializeField] internal static bool Claw = false;
    int GrappleCount = 2;
    int numberofgrapple = 0;
    private bool isGrounded;

    [SerializeField] Image markObject; 
    [SerializeField]
    Sprite SRankSprite;
    [SerializeField]
    Sprite ARankSprite;
    [SerializeField]
    Sprite BRankSprite;
    float grappleStartTime;
    bool isTimerRunning;
    float markDisplayTime;

    void Start()
    {
        Distancejoint.autoConfigureDistance = true;
        Distancejoint.enabled = false;
        lineRenderer.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        markObject.enabled = false;
    }

    void Update()
    {
        if (numberofgrapple < GrappleCount)
        {
            Grapple();
        }

        if (!Claw)
        {
            GrappleCount = 2;
        }
        else
        {
            GrappleCount = 3;
        }

        isGrounded = (Physics2D.Raycast(Ray.position, Vector2.down, 0.5f, floorLayerMask).collider != null);
        if (isGrounded)
        {
            numberofgrapple = 0;
        }

        if (isTimerRunning)
        {
            float timeGrappled = Time.time - grappleStartTime;

            if (timeGrappled >= 1 && timeGrappled <= 2)
            {
                ShowMark(SRankSprite);
            }
            else if (timeGrappled >= 2.1f && timeGrappled <= 3)
            {
                ShowMark(ARankSprite);
            }
            else if (timeGrappled >= 3.1 && timeGrappled <= 4)
            {
                ShowMark(BRankSprite);
            }
            else if (timeGrappled >= 4)
            {
                HideMark();
            }
        }
    }

    private void Grapple()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grappleStartTime = Time.time;
            isTimerRunning = true;

            Vector2 mousepos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousepos);
            lineRenderer.SetPosition(1, transform.position);
            Distancejoint.connectedAnchor = mousepos;
            Distancejoint.enabled = true;
            LinePosition.position = mousepos;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Distancejoint.enabled = false;
            lineRenderer.enabled = false;
            numberofgrapple++;
            isTimerRunning = false;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 Direction = LinePosition.position - transform.position;
            rb.velocity = new Vector2(Direction.x * force, Direction.y * force).normalized * force * Time.deltaTime;
            Distancejoint.enabled = false;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Distancejoint.enabled = true;
        }
    }

    void ShowMark(Sprite sprite)
    {
        markObject.sprite = sprite;
        markObject.enabled = true;
    }

    void HideMark()
    {
        markObject.enabled = false;
    }
}
