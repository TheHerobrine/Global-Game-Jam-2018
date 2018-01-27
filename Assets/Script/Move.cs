using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float acceleration = 1f;
    public Vector3 orientation;

    public GameObject animator;

    public float moveLimit = 0.001f;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        float deltaX = inputX * acceleration * Time.deltaTime;
        float deltaY = inputY * acceleration * Time.deltaTime;
        Vector3 speed = new Vector3(deltaX, deltaY, 0f);
        //Vector3 Rotation = new Vector3(0f, 0f, Mathf.Acos(deltaX/deltaY));
        if (speed.sqrMagnitude >= moveLimit)
        {
            this.transform.Translate(new Vector3(deltaX, deltaY, 0.0f));
            orientation = new Vector3(inputX, inputY, 0f);
            orientation.Normalize();
            //rigidBody.MovePosition(rigidBody.position + (Vector2)speed * Time.deltaTime);
            animator.transform.rotation = Quaternion.LookRotation(Vector3.forward, speed);
        }
        else
        {

        }
        
        Debug.DrawLine(this.transform.position, this.transform.position + orientation);
	}
}
