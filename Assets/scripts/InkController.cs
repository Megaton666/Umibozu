using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkController : MonoBehaviour {

    public float speed;
	void Start ()
    {
		
	}
	
	
	void FixedUpdate ()
    {
        Vector3 Position = transform.position;
        Position += transform.up * speed;
        Position.y -= 0.02f;
        transform.position = Position;
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
