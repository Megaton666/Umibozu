using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalShadow : MonoBehaviour {

	private new SpriteRenderer renderer;
    private float startTime;
    void Start ()
    {
        transform.position = new Vector3(-2, 5, 0);
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(255, 255, 255, 0);
        startTime = Time.time;
        StartCoroutine(Eyes());
	}
	
	void FixedUpdate ()
    {
        float t = (Time.time - startTime) / 1.5f;
        renderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0, 1f, t));
    }

    IEnumerator Eyes()
    {
        yield return new WaitForSeconds(5);
    }
}
