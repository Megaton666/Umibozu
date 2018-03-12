using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidController : MonoBehaviour {

    public int Health;
    public float Speed;
    public AudioClip onDeathSound;
    public AudioClip shootSound;
    public Object inkBall;
    public RuntimeAnimatorController deathAnim;
    public AnimationClip anim;

    private bool IsAlive = true;
    private GameObject player;
    private Animator animator;
    private AudioSource audiosource;
    private bool IsSpooked = false;
    private bool InCooldown = true;

    void Start ()
    {
		audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        StartCoroutine(WaitForCooldown());
    }
	

	void FixedUpdate ()
    {
        if (IsAlive)
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
                Vector3 direction = transform.position - player.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector3 Position = transform.position;
                Position -= transform.up * Speed;
                Position.y -= 0.02f;
                transform.position = Position;
            }
            if (Health <= 0)
            {
                IsAlive = false;
                Destroy(transform.GetChild(0).gameObject);
                StartCoroutine(OnDeath());
            }
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
        if ((other.gameObject.CompareTag("Spawn") || other.gameObject.CompareTag("Screen")) && GetComponent<Collider2D>().enabled)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpitInk()
    {
        InCooldown = true;
        if (Random.Range(0, 4) == 0)
        {
            Quaternion rot = Quaternion.FromToRotation(Vector2.up, Vector2.right);
            Instantiate(inkBall, transform.position, rot);
            rot = Quaternion.FromToRotation(Vector2.up, Vector2.left);
            Instantiate(inkBall, transform.position, rot);
            audiosource.PlayOneShot(shootSound, 0.5f);
        }
        yield return new WaitForSeconds(2);
        InCooldown = false;
    }

    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(3);
        InCooldown = false;
    }

    IEnumerator OnDeath()
    {
        animator.runtimeAnimatorController = deathAnim;
        audiosource.PlayOneShot(onDeathSound);
        Speed = 0;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(anim.length - 0.2f);
        Destroy(gameObject);
    }
}
