using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public static Move instance = null;

    public float acceleration = 1f;
    public Vector3 orientation;

    public GameObject orientedObject;
    private Animator animator;
    private AudioSource audio;

    public float moveLimit = 0.1f;
    public bool moveLocked;
    public float minAnimationSpeed = 0.2f;
    public float maxAnimationSpeed = 1.5f;

    public int Progress;
    private bool Progress1;
    private bool Progress2;
    private bool Progress3;

    public AudioClip progress1_clip;
    public GameObject progress1_object;
    public AudioClip progress2_clip;
    public GameObject progress2_object;
    public AudioClip progress3_clip;
    public GameObject progress3_object;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Progress1 = false;
        Progress2 = false;

        audio = GetComponent<AudioSource>();
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
            if (!moveLocked)
            {
                //this.transform.Translate(new Vector3(deltaX, deltaY, 0.0f));
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(deltaX, deltaY, 0.0f) / Time.deltaTime;

			    animator.speed = Mathf.Lerp(minAnimationSpeed, maxAnimationSpeed, speed.normalized.sqrMagnitude);
                orientation = new Vector3(inputX, inputY, 0f);
                orientation.Normalize();
                //rigidBody.MovePosition(rigidBody.position + (Vector2)speed * Time.deltaTime);
                orientedObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, speed);
            }
        }
		else
		{
			this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}

        if(moveLocked)
        {
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Moving", moveLocked || speed.normalized.sqrMagnitude >= moveLimit);
        }
        
        Debug.DrawLine(this.transform.position, this.transform.position + orientation);
	}

    public void checkProgress()
    {
        if (Progress > 3 &&
            !Progress1)
        {
            Progress1 = true;
            audio.clip = progress1_clip;
            audio.Play();
            progress1_object.SetActive(true);
        }
        if (Progress > 4 &&
            !Progress2)
        {
            Progress2 = true;
            audio.clip = progress2_clip;
            audio.Play();
            progress2_object.SetActive(false);
        }
        if(Progress > 5 &&
            !Progress3)
        {
            Progress3 = true;
            audio.clip = progress3_clip;
            audio.Play();
            progress3_object.SetActive(false);
        }
    }
}
