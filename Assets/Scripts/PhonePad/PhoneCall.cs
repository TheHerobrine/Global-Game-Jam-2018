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

    private AudioSource audioSource;
    private bool close;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        pos = 0;
        close = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(close)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            Move.instance.moveLocked = false;
            close = false;
        }
	}

    public void receiveInput(int number)
    {
        if(combination[pos] == number)
        {
            if(pos == combination.Length - 1 )
            {
                audioSource.clip = resultSound;
                audioSource.Play();
                close = true;
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
