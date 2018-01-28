using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadImage : MonoBehaviour {

    private bool bappear;
    private bool bdisappear;
    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(bappear)
        {
            GetComponent<CanvasGroup>().alpha += speed * Time.deltaTime;
            if(GetComponent<CanvasGroup>().alpha >= 1.0f)
            {
                bappear = false;
            }
        }
        if (bdisappear)
        {
            GetComponent<CanvasGroup>().alpha -= speed * Time.deltaTime;
            if (GetComponent<CanvasGroup>().alpha <= 0.0f)
            {
                bdisappear = false;
            }
        }
    }

    public void appear()
    {
        bappear = true;
    }

    public void disappear()
    {
        bdisappear = true;
    }
}
