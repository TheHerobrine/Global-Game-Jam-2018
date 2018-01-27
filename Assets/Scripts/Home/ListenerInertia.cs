using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerInertia : MonoBehaviour {

    public float rotationInertia;
    public GameObject animator;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion targetRotation = animator.transform.rotation;
        Quaternion sourceRotation = transform.rotation;

        transform.rotation = Quaternion.Lerp(sourceRotation, targetRotation, rotationInertia * Time.deltaTime);
	}
}
