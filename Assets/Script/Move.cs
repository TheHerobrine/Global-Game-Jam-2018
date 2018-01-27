using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float acceleration = 1f;
    public Vector3 orientation;

    public GameObject orientedObject;
    private Animator animator;

    public float moveLimit = 0.1f;

    public float minAnimationSpeed = 0.2f;
    public float maxAnimationSpeed = 1.5f;

    private void Awake()
    {
        animator = orientedObject.GetComponent<Animator>();
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
        if (speed.normalized.sqrMagnitude >= moveLimit)
        {
            this.transform.Translate(new Vector3(deltaX, deltaY, 0.0f));
            animator.speed = Mathf.Lerp(minAnimationSpeed, maxAnimationSpeed, speed.normalized.sqrMagnitude);
            orientation = new Vector3(inputX, inputY, 0f);
            orientation.Normalize();
            //rigidBody.MovePosition(rigidBody.position + (Vector2)speed * Time.deltaTime);
            orientedObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, speed);
        }

        animator.SetBool("Moving", speed.normalized.sqrMagnitude >= moveLimit);
        
        Debug.DrawLine(this.transform.position, this.transform.position + orientation);
	}
}
