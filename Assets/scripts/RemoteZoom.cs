using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteZoom : MonoBehaviour {

    private float zoom;
	void Start ()
    {
        zoom = GetComponent<Camera>().orthographicSize;
	}
	
	
	void FixedUpdate ()
    {
		if (zoom > GetComponent<Camera>().orthographicSize)
        {
            GetComponent<Camera>().orthographicSize += 0.005f;
        }
	}

    public void Zoom(float newZoom)
    {
        zoom = newZoom;
    }
}
