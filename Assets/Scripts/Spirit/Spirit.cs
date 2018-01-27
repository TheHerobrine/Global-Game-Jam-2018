using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public GameObject tracked;
    public float speed;
    public float trackingRadius;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector3 direction = tracked.transform.position - transform.position;
        direction.z = 0f;
        if (direction.sqrMagnitude > trackingRadius)
        {
            rb.AddForce(new Vector2(direction.x, direction.y) * direction.sqrMagnitude * speed);
        }
        else
        {
            rb.AddForce(new Vector2(direction.y, -direction.x) * 0.8f * speed);
        }
    }
}
