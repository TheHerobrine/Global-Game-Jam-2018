using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnterRoom : MonoBehaviour
{

    public GameObject Door;

    private AudioSource DoorSound;
    private bool fadeStarted = false;
    private void Awake()
    {
        DoorSound = Door.GetComponent<AudioSource>();
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
        DoorSound.Play();
        StartCoroutine("OpenDoor");
        StartCoroutine("Fade");
    }

    IEnumerator OpenDoor()
    {
        for (float f = 0f; f < 90; f += 1f)
        {
            Door.transform.Rotate(0f, 0f, -1f);
            yield return null;
        }
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
