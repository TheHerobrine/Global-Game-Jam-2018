using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
	public float time = 0.5f;

	public float Alphafrom;
	public float Alphato;

	public float chrono = 0.0f;

	public SpriteRenderer Srenderer;

	// Use this for initialization
	void Start ()
	{
		Srenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		chrono -= Time.deltaTime;
		if (chrono < 0)
		{
			Alphafrom = Alphato;
			Alphato = Mathf.Sqrt(Random.Range(0.5f, 1.2f));
			chrono += time;
		}

		Color tcolor = Srenderer.color;
		tcolor.a = (chrono / time) * Alphafrom + (1 - (chrono / time)) * Alphato;
		Srenderer.color = tcolor;
	}
}
