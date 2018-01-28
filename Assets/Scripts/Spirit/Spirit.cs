using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public GameObject tracked;
    public float speed;
    public float radius = 0.35f;
    public float freq = 1.5f;

	public Vector3 lastPosition;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	public void Update()
	{
		/*
		Vector3 distance = (tracked.transform.position - transform.position);
		distance.z = 0.0f;

		if (distance.magnitude < 0.05f)
		{
			float force = (1.0f / (distance.magnitude * 5.0f)) - 1 / 0.25f;
			Debug.Log(force);
			rb.AddForce(distance.normalized * -1.0f * force);
		}
		*/

		Vector3 circle = new Vector3(Mathf.Cos(Time.realtimeSinceStartup * freq), Mathf.Sin(Time.realtimeSinceStartup * freq) + 0.1f, 0.0f) * radius;
		Vector3 direction = tracked.transform.position + circle - transform.position;
		direction.z = 0.0f;
		Vector2 moveDir = new Vector2();
		/*
		if (direction.sqrMagnitude > trackingRadius)
		{
			moveDir = new Vector2(direction.x, direction.y) * direction.sqrMagnitude * speed;
		}
		else
		{
			moveDir = new Vector2(direction.y, -direction.x) * 0.8f * speed;
		}
		*/

		moveDir = direction.normalized * speed * Mathf.Max(direction.sqrMagnitude, 1.0f);

		rb.AddForce(moveDir);

		//transform.rotation = Quaternion.LookRotation(Vector3.forward, (lastPosition - transform.position).normalized);
		/*
		if ((lastPosition - transform.position).magnitude > 0.2f)
		{
			lastPosition = (transform.position * 1.8f + lastPosition * 0.2f) / 2.0f;
		}
		*/
	}
}
