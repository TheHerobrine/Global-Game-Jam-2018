using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnterRoom : MonoBehaviour
{
    private Renderer renderer;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        Debug.Log("Bidule");
        Color color = GetComponent<Renderer>().material.color;
        color.a = 1f;

        GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
