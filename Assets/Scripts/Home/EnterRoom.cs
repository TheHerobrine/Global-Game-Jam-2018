using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class EnterRoom : MonoBehaviour
{

    public GameObject Door;
    public GameObject FogOfwar;

    private AudioSource DoorSound;
    private Renderer RendererFogOfwar;
    private bool fadeStarted = false;
    private void Awake()
    {
        DoorSound = this.GetComponent<AudioSource>();
        RendererFogOfwar = FogOfwar.GetComponent<Renderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (fadeStarted)
            return;
        Debug.Log("Trigger");
        if (Input.GetButtonDown("Fire1"))
        {
            fadeStarted = true;
            DoorSound.Play();
            StartCoroutine("OpenDoor");
            Color c = RendererFogOfwar.material.color;
            Debug.Log(c);
            if(c.a == 1f)
                StartCoroutine("Fade");
            this.enabled = false;
        }
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
        Color c = RendererFogOfwar.material.color;
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            c.a = f;
            RendererFogOfwar.material.color = c;
            yield return null;
        }
        this.enabled = false;
    }
}
