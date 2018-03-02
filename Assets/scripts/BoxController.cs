using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    public int charge;

    void Start () {
	}
	
	void FixedUpdate () {
        Vector3 Position = transform.position;
        Position.y -= 0.02f;
        transform.position = Position;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn") || other.gameObject.CompareTag("Screen"))
        {
            Destroy(gameObject);
        }
    }
}
