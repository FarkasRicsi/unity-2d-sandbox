using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector2 direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
