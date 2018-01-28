using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneIntro : MonoBehaviour {

    public GameObject girl1;
    public float time1;
    public GameObject girl2;
    public float time2;
    public GameObject girl3;

    private bool activate1;
    private bool activate2;
    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > time1 && !activate1)
        {
            activate1 = true;
            girl1.GetComponent<FadImage>().disappear();
            girl2.GetComponent<FadImage>().appear();
        }
        if (timer > time2 && !activate2)
        {
            activate2 = true;
            girl2.GetComponent<FadImage>().disappear();
            girl3.GetComponent<FadImage>().appear();
        }
    }
}
