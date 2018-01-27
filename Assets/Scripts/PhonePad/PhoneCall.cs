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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        pos = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void receiveInput(int number)
    {
        if(combination[pos] == number)
        {
            if(pos == combination.Length - 1 )
            {
                audioSource.clip = resultSound;
                audioSource.Play();
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
