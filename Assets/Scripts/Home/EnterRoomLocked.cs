using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class EnterRoomLocked : MonoBehaviour
{

    private AudioSource DoorLocked;
    
    private void Awake()
    {
        DoorLocked = this.GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetButton("Fire1"))
        {
            DoorLocked.Play();        
        }
    }
}
