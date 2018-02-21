using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public int range;
    public AudioClip splash;
    public AudioClip pickupDestroySound;
    public AudioClip harpoonFire;
    public AudioClip harpoonHold;

    private float speed;
    private float Distance;
    private AudioSource audiosource;
    
    void Start()
    {
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        audiosource.clip = harpoonHold;
        audiosource.Play();
        Distance = 0;
        speed = 0.0f;
    }

    void FixedUpdate()
    {
        if (!Input.GetMouseButton(0) && Distance == 0)
        {
            audiosource.Stop();
            transform.parent = null;
            speed = 0.2f;
            audiosource.PlayOneShot(harpoonFire);
        }
        Vector3 Position = transform.position;
        Position += transform.up * speed;
        transform.position = Position;
        Distance += speed;
        if (Distance >= range - (GetComponent<SpriteRenderer>().bounds.size.x))
        { 
            audiosource.PlayOneShot(splash, 0.5f);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("PowerUp"))
        {
            audiosource.PlayOneShot(pickupDestroySound);
            Destroy(other);
            Destroy(gameObject);
        }
    }


}