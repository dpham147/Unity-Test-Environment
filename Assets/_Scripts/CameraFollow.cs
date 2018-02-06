using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;    // Stores the transform of the object to follow
    public float smoothing = 5f;     // Smoothing value for camera movement

    private Vector3 offset;     // Follow distance of camera

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.position;  // Initializes offset on startup
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;    // Vector3 of the camera position
        // Moves the camera to position
        // Vector3.Lerp will interpolate between positions
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);    
	}
}
