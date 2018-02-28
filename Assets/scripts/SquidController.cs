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
    private bool InCooldown = true;

    void Start ()
    {
		audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        StartCoroutine(WaitForCooldown());
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
 
                StartCoroutine(SpitInk());
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

    IEnumerator SpitInk()
    {
        InCooldown = true;
        if (Random.Range(0, 3) == 0)
        {
            Quaternion rot = Quaternion.FromToRotation(Vector2.up, Vector2.right);
            Instantiate(inkBall, transform.position, rot);
            rot = Quaternion.FromToRotation(Vector2.up, Vector2.left);
            Instantiate(inkBall, transform.position, rot);
        }
        yield return new WaitForSeconds(1);
        InCooldown = false;
    }

    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(3);
        InCooldown = false;
    }
}
