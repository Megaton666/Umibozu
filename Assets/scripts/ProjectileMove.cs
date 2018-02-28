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
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponents<AudioSource>()[2];
        audiosource.clip = harpoonHold;
        audiosource.volume = 1f;
        audiosource.Play();
        Distance = 0;
        speed = 0.0f;
    }

    void FixedUpdate()
    {
        if (!Input.GetButton("Fire1") && Distance == 0)
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

    void OnTriggerStay2D(Collider2D other)
    {
        if (speed != 0)
        {
            if (other.gameObject.CompareTag("Enemy1"))
            {
                other.GetComponent<SharkController>().Health--;
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Enemy2"))
            {
                other.GetComponent<SquidController>().Health--;
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
}