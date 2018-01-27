using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public AudioSource lockClick;
    public AudioSource lockOpen;
    public AudioSource goalSuccess;
    public SpriteRenderer lockCombinaisonRenderer;
    public float[] RotateGoals = new float[4];
    public float gapAcceptance = 10f;
    public bool openLock = false;

    private float currentRotate = 0;
    private float PreviousTurn = 0f;
    private bool returnToZero = false;
    private int iCurrentGoal = 0;
    private float loopTimer;
    // Use this for initialization
    void Start () {
		
	}
    
    IEnumerator ReturnToZero()
    {
        returnToZero = true;
        for (float r = 0; r < Mathf.Abs(currentRotate); r += 1f)
        {
            lockCombinaisonRenderer.transform.Rotate(0f, 0f, Mathf.Sign(PreviousTurn) * 1f);
            yield return null;
        }
        currentRotate = 0f;
        PreviousTurn = 0f;
        iCurrentGoal = 0;
        returnToZero = false;
    }
    void NextGoal()
    {
        if (iCurrentGoal == 3) {
            lockOpen.Play();
            openLock = true;
            return;
        }
        goalSuccess.Play();
        iCurrentGoal++;
    }
    // Update is called once per frame
    void Update()
    {
        if (openLock)
        {
            return;
        }

        loopTimer -= Time.deltaTime;
        //Debug.Log(loopTimer);
        if (loopTimer < 0)
        {
            lockClick.Play();
            loopTimer = Mathf.Abs(currentRotate - RotateGoals[iCurrentGoal])/50;
        }
        float horizontal = Input.GetAxis("Horizontal");
        if(!returnToZero && horizontal != 0.0f)
        {
            if (RotateGoals[iCurrentGoal]+gapAcceptance > currentRotate && currentRotate > RotateGoals[iCurrentGoal] - gapAcceptance)
            {
                NextGoal();
            }
            float PreviousGoal = iCurrentGoal == 0|| iCurrentGoal == 3 ? 0 : RotateGoals[iCurrentGoal-1];
            currentRotate += horizontal;
            lockCombinaisonRenderer.transform.Rotate(0f, 0f, horizontal);
            PreviousTurn = horizontal;
        }
    }
}
