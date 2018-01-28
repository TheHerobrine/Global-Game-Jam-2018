using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1") && Move.instance.moveLocked && gameObject.activeSelf)
        {
            Move.instance.moveLocked = false;
            gameObject.SetActive(false);
        }
    }
}
