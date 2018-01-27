using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDisplay : MonoBehaviour
{
	public GameObject shadowObject;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		shadowObject.GetComponent<SpriteRenderer>().sharedMaterial.SetVector("_FadeOrigin", transform.position);
	}
}
