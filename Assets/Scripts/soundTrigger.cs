using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour {

    public bool isLooped;
    public int loopTime;

    private AudioSource soundSource;
    private Collider2D[] colliders;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        colliders = GetComponents<Collider2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
