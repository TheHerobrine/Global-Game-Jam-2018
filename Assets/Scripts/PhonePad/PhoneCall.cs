using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class PhoneCall : MonoBehaviour {

    public int[] combination;
    public int pos;

    public AudioClip successSound;
    public AudioClip failureSound;
    public AudioClip resultSound;

    public float callTime;
    private float timer;

    private AudioSource audioSource;
    private bool close;
    private bool discovered;

    private void Awake()
    {
        discovered = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        pos = 0;
        timer = 0;
        close = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                close = true;
            }
        }

		if(close)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            Move.instance.moveLocked = false;
            close = false;
        }
	}

    public void closeCanvas()
    {
        close = true;
    }

    public void receiveInput(int number)
    {
        if(combination[pos] == number)
        {
            if(pos == combination.Length - 1 )
            {
                if(!discovered)
                {
                    discovered = true;
                    Move.instance.Progress++;
                    Move.instance.checkProgress();
                }
                audioSource.clip = resultSound;
                audioSource.Play();
                timer = callTime;
                pos = 0;
            }
            else
            {
                audioSource.clip = successSound;
                audioSource.Play();
                pos++;
            }
        }
        else
        {
            audioSource.clip = failureSound;
            audioSource.Play();
            pos = 0;
        }
    }
}
