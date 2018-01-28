using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneIntro : MonoBehaviour {

    public GameObject image1;
    public GameObject girl11;
    public float time11;
    public GameObject girl12;
    public float time12;
    public GameObject girl13;
    public float time13;
    public GameObject girl14;

    public float time20;
    public GameObject image2;
    public GameObject girl21;
    public float time21;
    public GameObject girl22;
    public float time22;
    public GameObject girl23;
    public float time23;

    private bool activate1;
    private bool activate2;
    private bool activate3;
    private bool activate4;
    private bool activate5;
    private bool activate6;
    private bool activate7;
    private float timer;

	// Use this for initialization
	void Start () {
        activate1 = false;
        activate2 = false;
        activate3 = false;
        activate4 = false;
        activate5 = false;
        activate6 = false;
        activate7 = false;
}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > time11 && !activate1)
        {
            activate1 = true;
            girl11.GetComponent<FadImage>().disappear();
            girl12.GetComponent<FadImage>().appear();
        }
        if (timer > time12 && !activate2)
        {
            activate2 = true;
            girl12.GetComponent<FadImage>().disappear();
            girl13.GetComponent<FadImage>().appear();
        }
        if (timer > time13 && !activate3)
        {
            activate3 = true;
            girl13.GetComponent<FadImage>().disappear();
            girl14.GetComponent<FadImage>().appear();
        }
        if (timer > time20 && !activate4)
        {
            activate4 = true;
            girl14.GetComponent<FadImage>().disappear();
            image1.GetComponent<FadImage>().disappear();
            girl21.GetComponent<FadImage>().appear();
            image2.GetComponent<FadImage>().appear();
        }
        if (timer > time21 && !activate5)
        {
            activate5 = true;
            girl21.GetComponent<FadImage>().disappear();
            girl22.GetComponent<FadImage>().appear();
        }
        if (timer > time22 && !activate6)
        {
            activate6 = true;
            girl22.GetComponent<FadImage>().disappear();
            girl23.GetComponent<FadImage>().appear();
        }
        if (timer > time23 && !activate7)
        {
            activate7 = true;
            image2.GetComponent<FadImage>().disappear();
            girl23.GetComponent<FadImage>().disappear();
        }
    }
}
