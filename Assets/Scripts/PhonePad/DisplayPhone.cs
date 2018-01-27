using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPhone : MonoBehaviour {

    public GameObject DisplayCanvas;
    public GameObject DisplayParticles;
    public GameObject PhoneSound;
    public GameObject SelectableButton;
   
    private bool clickable;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(clickable)
        {
            if (Input.GetButtonDown("Fire1") && !Move.instance.moveLocked)
            {
                Debug.Log("button pressed");
                PhoneSound.SetActive(false);
                DisplayCanvas.SetActive(true);
                SelectableButton.GetComponent<Button>().Select();
                Move.instance.moveLocked = true;
                
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
