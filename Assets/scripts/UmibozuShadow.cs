using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmibozuShadow : MonoBehaviour {

    public float speed;
    public float opacity;

    private new SpriteRenderer renderer;
    private bool rising;
    private float startTime;

    void Start () {
        Mathf.Clamp(opacity, 0, 1);
        transform.localScale *= opacity;
        renderer = GetComponent<SpriteRenderer>();
        Color temp = renderer.color;
        temp.a = 0f;
        renderer.color = temp;
        StartCoroutine(Fade());
        startTime = Time.time;
        rising = true;
    }
	

	void FixedUpdate () {
        if (rising)
        {
            float t = (Time.time - startTime) / 1.5f;
            renderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0, 1f * opacity, t));
        }
        else
        {
            float t = (Time.time - startTime) / 2f;
            renderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f * opacity, 0, t));
        }
        
        Vector3 Position = transform.position;
        Position += transform.up * speed;
        transform.position = Position;
        
    }

   IEnumerator Fade()
    {
        yield return new WaitForSeconds(5);
        rising = false;
        startTime = Time.time;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
