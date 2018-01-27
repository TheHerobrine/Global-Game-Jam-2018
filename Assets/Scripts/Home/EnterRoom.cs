using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnterRoom : MonoBehaviour
{
    private bool fadeStarted = false;
    private void Awake()
    {
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fadeStarted)
            return;
        fadeStarted = true;
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        Renderer renderer = this.GetComponent<Renderer>();
        Color c = renderer.material.color;
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            c.a = f;
            renderer.material.color = c;
            yield return null;
        }
        this.enabled = false;
    }
}
