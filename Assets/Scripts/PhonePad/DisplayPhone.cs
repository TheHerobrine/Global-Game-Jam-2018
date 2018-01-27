using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPhone : MonoBehaviour {

    public GameObject DisplayCanvas;
    public GameObject DisplayParticles;
    public GameObject PhoneSound;

    private bool clickable;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(clickable)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("button pressed");
                PhoneSound.SetActive(false);
                DisplayCanvas.SetActive(true);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        clickable = true;
        DisplayParticles.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        clickable = false;
        DisplayParticles.SetActive(false);
    }
}
