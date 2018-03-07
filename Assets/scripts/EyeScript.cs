using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeScript : MonoBehaviour {

    private new SpriteRenderer renderer;
    private float startTime;
	void Start () {
        startTime = Time.time;
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(255, 255, 255, 0);
    }
	
	void FixedUpdate () {
        float t = (Time.time - startTime) / 1.5f;
        renderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0, 1f, t));
    }
}
