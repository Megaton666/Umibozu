using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

    public int Health;
    public float Speed;
    public AudioClip onDeathSound;
    public RuntimeAnimatorController deathAnim;
    public AnimationClip anim;

    private bool IsAlive = true;
    private Animator animator;
    private AudioSource audiosource;
    void Start ()
    {
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
	
	void FixedUpdate () {
        Vector3 Position = transform.position;
        Position += transform.up * Speed;
        Position.y -= 0.02f;
        transform.position = Position;
        if (Health <= 0 && IsAlive)
        {
            IsAlive = false;
            StartCoroutine(OnDeath());
        }
	}


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn") && GetComponent<Collider2D>().enabled)
        {
            Destroy(gameObject);
           
        }
    }
    IEnumerator OnDeath()
    {
        animator.runtimeAnimatorController = deathAnim;
        audiosource.PlayOneShot(onDeathSound);
        Speed = 0;
        GetComponent<Collider2D>().enabled = false;
        //Debug.Log("die");
        yield return new WaitForSeconds(anim.length - 0.2f);
        Destroy(gameObject);
    }
}
