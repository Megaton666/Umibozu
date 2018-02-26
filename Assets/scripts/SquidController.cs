using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidController : MonoBehaviour {

    public int Health;
    public float Speed;
    public AudioClip onDeathSound;
    public Object inkBall;

    private GameObject player;
    private AudioSource audiosource;
    private bool IsSpooked = false;
    private bool InCooldown = false;

    void Start ()
    {
		audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }
	

	void FixedUpdate ()
    {
        
        if (!IsSpooked)
        {
            Vector3 Position = transform.position;
            Position.y -= 0.02f;
            transform.position = Position;
            if (!InCooldown)
            {
 
                StartCoroutine(spitInk());
            }
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 Position = transform.position;
            Position += transform.up * Speed;
            Position.y -= 0.02f;
            transform.position = Position;
        }
        if (Health <= 0)
        {
            audiosource.PlayOneShot(onDeathSound);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Siren"))
        {
            IsSpooked = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn") || other.gameObject.CompareTag("Screen"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator spitInk()
    {
        InCooldown = true;
        if (Random.Range(0, 3) == 0)
        {
            Quaternion rot = Quaternion.FromToRotation(Vector2.up, player.transform.position - transform.position);
            Instantiate(inkBall, transform.position, rot);
        }
        yield return new WaitForSeconds(1);
        InCooldown = false;
    }
}
