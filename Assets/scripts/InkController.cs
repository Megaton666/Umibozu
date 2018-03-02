using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkController : MonoBehaviour {

    public float speed;

    private float Distance;

	void Start ()
    {
        Distance = 0;
	}
	void Update()
    {
        if (Distance >= 6)
        {
            Destroy(gameObject);
        }
    }
	
	void FixedUpdate ()
    {
        Vector3 Position = transform.position;
        Position += transform.up * speed;
        Position.y -= 0.02f;
        transform.position = Position;
        Distance += speed;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn") || other.gameObject.CompareTag("Screen"))
        {
            Destroy(gameObject);
        }
    }
}
