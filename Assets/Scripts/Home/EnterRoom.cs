using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class EnterRoom : MonoBehaviour
{

    public GameObject Door;
    public GameObject[] FogOfwar;

    private AudioSource DoorSound;
    private Renderer[] RendererFogOfwar;
    private bool fadeStarted = false;
    private void Awake()
    {
        DoorSound = this.GetComponent<AudioSource>();
        RendererFogOfwar = new Renderer[FogOfwar.Length];
        for (int i=0; i<FogOfwar.Length; i++)
        {
            RendererFogOfwar[i] = FogOfwar[i].GetComponent<Renderer>();
        }
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
        if (Input.GetButton("Fire1"))
        {
            fadeStarted = true;
            DoorSound.Play();
            StartCoroutine("FadeDoor");
            for (int i=0; i< RendererFogOfwar.Length; i++)
            {
                Color c = RendererFogOfwar[i].material.color;
                if (c.a == 1f)
                    StartCoroutine("FadeFogOfWar", i);
            }
            this.enabled = false;
        }
    }

    IEnumerator FadeDoor()
    {
        Renderer DoorRenderer = Door.GetComponent<Renderer>();
        Color c = DoorRenderer.material.color;
        for (float f = 1f; f >= 0; f -= 0.06f)
        {
            c.a = f;
            DoorRenderer.material.color = c;
            yield return null;
        }
        Door.SetActive(false);
        /*for (float f = 0f; f < 90; f += 1f)
        {
            Door.transform.Rotate(0f, 0f, -1f);
            yield return null;
        }*/
    }

    IEnumerator FadeFogOfWar(int i)
    {
        Color c = RendererFogOfwar[i].material.color;
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            c.a = f;
            RendererFogOfwar[i].material.color = c;
            yield return null;
        }
        this.enabled = false;
    }
}
