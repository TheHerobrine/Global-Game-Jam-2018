using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollScript : MonoBehaviour
{
	public float fadeTime;
	public float finalFade;
	public float startTime;
	public float speed;
	public float stopPos;
	public GameObject subScroll;

	public float chrono;
	public float chronoFade;

	// Use this for initialization
	void Start ()
	{
		chrono = 0.0f;
		chronoFade = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		chrono += Time.deltaTime;

		if (chrono < fadeTime)
		{
			this.GetComponent<CanvasGroup>().alpha = chrono / fadeTime;
		}
		else
		{
			this.GetComponent<CanvasGroup>().alpha = 1.0f;

			float newPos = (chrono - fadeTime) * speed;
			if (newPos > stopPos)
			{
				if (chronoFade > finalFade)
				{
					this.GetComponent<CanvasGroup>().alpha = 1.0f - (chronoFade - finalFade) / finalFade;
					if (chronoFade > finalFade*2.0f)
					{
						SceneManager.LoadScene("menu");
					}
				}
				subScroll.transform.position = new Vector3(0.0f, newPos, 0.0f);
				chronoFade += Time.deltaTime;
			}
			else
			{
				this.transform.position = new Vector3(0.0f, newPos, 0.0f);
			}
		}
	}
}
