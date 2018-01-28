using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

	public float chrono;

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;

	public GameObject group;

	public float t1;
	public float groupx;
	public float groupy;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		chrono += Time.deltaTime;

		if (chrono < 10.0f)
		{
			p3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			Vector3 gFrom = new Vector3(-groupx, -groupy, 0.0f);
			Vector3 gTo = new Vector3(groupx, groupy, 0.0f);

			float timer = chrono / 10.0f;

			group.transform.position = gFrom * timer + gTo * (1.0f - timer);

			if (chrono < 5.0f)
			{
				timer = chrono / 5.0f;
				p1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Pow((1 - Mathf.Cos(timer * 2.0f * Mathf.PI)) / 2.0f, 0.5f));
				p2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			}
			else
			{
				timer = chrono / 5.0f - 1.0f;
				p2.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Pow((1 - Mathf.Cos(timer * 2.0f * Mathf.PI)) / 2.0f, 0.5f));
				p1.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

			}
		}
		else
		{
			float timer = chrono - 10.0f;
			if (timer < 10.0f)
			{
				p3.transform.position = new Vector3(0.0f, -3.5f + 7.0f * (1 - Mathf.Cos((timer / 20.0f) * 2.0f * Mathf.PI)) / 2.0f, 0.0f);
			}
			else
			{
				p3.transform.position = new Vector3(0.0f, 3.5f, 0.0f);
			}

			if (timer < 5.0f)
			{
				timer /= 10.0f;
				p3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Pow((1 - Mathf.Cos(timer * 2.0f * Mathf.PI)) / 2.0f, 0.5f));
			}
			else
			{
				p3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			}
			if (timer > 10.0f)
			{
				p3.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f - (timer - 10.0f) / 5.0f);
			}
		}
	}
}
