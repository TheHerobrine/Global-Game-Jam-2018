using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
	[Range(0.0f, 1.0f)]
	public float blinkProb = 0.3f;

	public float minTime = 0.2f;
	public float chrono;

	public SpriteRenderer lightRenderer;

	// Use this for initialization
	void Start ()
	{
		lightRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		chrono += Time.deltaTime;

		if (chrono > minTime)
		{
			chrono -= minTime;

			if (Random.Range(0.0f, 1.0f) > blinkProb)
			{
				lightRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			}
			else
			{
				lightRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			}
		}
	}
}
