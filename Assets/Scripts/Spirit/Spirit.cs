using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public GameObject tracked;
    public float speed;
    public float trackingRadius;
    public float oscillateFreq = 1f;
    public float oscillateOffset = 150f;
    public float oscillateMagnitude = 0.2f;

    public void Update()
    {
        Vector3 direction = tracked.transform.position - transform.position;
        direction.z = 0f;
        if (direction.sqrMagnitude > trackingRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, tracked.transform.position, Time.deltaTime * speed);
        }
    }
}
