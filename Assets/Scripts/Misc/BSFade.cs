using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSFade : MonoBehaviour
{
	public float fadeTime;
	public float fade;

	// Use this for initialization
	void Start ()
	{
		fade = 0.0f;
		GetComponent<CanvasGroup>().alpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.fade > 1.0f)
		{
			this.gameObject.SetActive(false);
			return;
		}
		this.fade += Time.deltaTime / this.fadeTime;
		GetComponent<CanvasGroup>().alpha = 1.0f - this.fade;
		return;
	}
}
