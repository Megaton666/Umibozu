using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

    public int Health;
    public float Speed;
    public AudioClip onDeathSound;

    private AudioSource audiosource;
    void Start ()
    {
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
    }
	
	void FixedUpdate () {
        Vector3 Position = transform.position;
        Position += transform.up * Speed;
        Position.y -= 0.02f;
        transform.position = Position;
        if (Health <= 0)
        {
            audiosource.PlayOneShot(onDeathSound);
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
