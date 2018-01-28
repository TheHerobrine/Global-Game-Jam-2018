using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraHandler : MonoBehaviour
{
    public float outsideSize = 4f;
    public float insideSize = 1f;
    public float zoomSpeed = 1f;

    public EnvironmentManager envManager;
    public Camera cameraTarget;

    void Start()
    {
        cameraTarget.orthographicSize = insideSize;
    }


	void Update()
    {
        float targetSize = envManager.outside ? outsideSize : insideSize;
        cameraTarget.orthographicSize += (targetSize - cameraTarget.orthographicSize) * zoomSpeed * Time.deltaTime;
	}
}
