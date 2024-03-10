using Unity.VisualScripting;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField]
    float BulletSpeed;
    Rigidbody2D bulletRB;

    void Start()
    {
    bulletRB = GetComponent<Rigidbody2D>();
    bulletRB.velocity = -(transform.right * BulletSpeed);
    Destroy(gameObject, 5);
    }

}
