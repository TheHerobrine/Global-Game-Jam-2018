using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour {

    public bool isLooped;
    public float loopTime;

    private AudioSource soundSource;
    private Rigidbody2D parentRigidbody;
    private Collider2D triggerCollider;
    private float loopTimer;
    private bool triggered;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<Collider2D>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            loopTimer -= Time.deltaTime;
            Debug.Log("loopTime " + loopTimer);
            if(loopTimer < 0)
            {
                soundSource.Play();
                loopTimer = loopTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        Debug.Log("Enter Colision");
        soundSource.mute = false;
        soundSource.Play();
        loopTimer = loopTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
        Debug.Log("Leave Colision");
        soundSource.mute = true;
        soundSource.Pause();
        loopTimer = 0;
    }
}
