﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public float radius;
    public float rotationSpeeed = 1;
    public float baseSpeed = 1f;
    public float rotateOffset = 0f;
    public float rotateFreq = 1f;
    public float rotateMagnitude = 1f;
    public float oscillateOffset = 0f;
    public float oscillateFreq = 1f;
    public float oscillateMagnitude = 0.2f;
    public float excitation = 1f;
    public float zoomMagnitude = 0.1f;
    public float zoomOffset = 0f;

    public GameObject satellite;

    public void Update()
    {
        satellite.transform.localPosition = new Vector3(oscillateMagnitude * Mathf.Cos(oscillateOffset + excitation * Time.time * oscillateFreq), 0f, 0f);
        transform.RotateAround(
            transform.parent.position,
            Vector3.back,
            excitation * (baseSpeed + rotateMagnitude * (Mathf.Cos(rotateOffset + Time.time * rotateFreq) + 1f))
        );
        satellite.transform.localScale = (1 + (Mathf.Cos(zoomOffset + excitation * Time.time * oscillateFreq) * zoomMagnitude)) * Vector3.one;
    }
}
