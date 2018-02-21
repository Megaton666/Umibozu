using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int MaxHealth;
    public float MaxSpeedInit;
    public float AccelInit;
    public Slider Healthbar;
    public AudioClip PowerupSound;
    public AudioClip EnemycollideSound;
    public AudioClip HarpoonLoad;
    public AudioClip GameoverSound;
    public AudioClip batteryReload;
    public AudioClip cooldownSound;
    public GameObject projectile;
    public GameObject GameOverScreen;
    public GameObject gameOverMenu;


    private float rotationZ = 0f;
    private bool IsInvincible = false;
    private float Accel;
    private float timestamp;
    private float cooldown;
    private Rigidbody2D rb;
    private AudioSource audiosource;
    private Transform harpoon;

    [HideInInspector]
    public int Health;
    public float MaxSpeed;

    void Start ()
    {
        GameOverScreen.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        harpoon = transform.Find("Harpoon");
        MaxSpeed = MaxSpeedInit;
        Accel = AccelInit;
        cooldown = 1.5f;
        Health = MaxHealth;
        Healthbar.maxValue = Health;
    }


    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
     
        rb.velocity += new Vector2(moveHorizontal * Accel, moveVertical * Accel);
        LimitSpeed();
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= timestamp)
            {
                StartCoroutine(FireHarpoon());
                timestamp = Time.time + cooldown;
            }
            else
            {
                audiosource.PlayOneShot(cooldownSound);
            }
        }
        TurnSideways(moveHorizontal);
        HealthbarFill();
        Boundaries(8.4f, 3.7f);
        CheckAlive();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !IsInvincible )
        {
            TakeDamage(1);
            audiosource.PlayOneShot(EnemycollideSound, 2f);
            StartCoroutine(InvulnTimer());
        }
        //else if (other.gameObject.CompareTag("PowerUp"))
        //{
        //    other.gameObject.SetActive(false);
        //    int randNum = Random.Range(0, 2);
        //    if (randNum == 1)
        //    {
        //        audiosource.PlayOneShot(PowerupSound, 1.5f);
        //        StartCoroutine(PowerUpTime(5));
        //    }
        //    else
        //    {
        //        GameObject.Find("Searchlight").GetComponent<SearchlightOnOff>().battery = 100;
        //        audiosource.PlayOneShot(batteryReload, 1.5f);
        //    }
        //}
        
    }

    void CheckAlive()
    {
        if (Healthbar.value <= 0)
        {
            audiosource.PlayOneShot(GameoverSound, 2.0f);
            GameOverScreen.SetActive(true);
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void TurnSideways(float moveHorizontal)
    {
        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("left") || Input.GetKey("right"))
        {
            rotationZ += Mathf.Pow(moveHorizontal, 3) / 2;
        }
        else
        {
            rotationZ -= Mathf.Sign(rotationZ) / 2;
        }
        rotationZ = Mathf.Clamp(rotationZ, -30, 30);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
    }
    void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void HealthbarFill()
    {
        if (Healthbar.value > Health)
        {
            Healthbar.value -= MaxHealth * 0.01f;
        }
        else if (Healthbar.value < Health)
        {
            Healthbar.value = Health;
        }
    }
    IEnumerator FireHarpoon()
    {
        audiosource.PlayOneShot(HarpoonLoad);
        yield return new WaitForSeconds(0.8f);
        Instantiate(projectile, harpoon.transform.position, harpoon.transform.rotation).transform.parent = harpoon.transform;
    }
    IEnumerator InvulnTimer()
    {
        IsInvincible = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        IsInvincible = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    void LimitSpeed()
    {
        if (rb.velocity.x > MaxSpeed)
        {
            rb.velocity = new Vector2(MaxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -MaxSpeed)
        {
            rb.velocity = new Vector2(-MaxSpeed, rb.velocity.y);
        }

        if (rb.velocity.y > MaxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, MaxSpeed);
        }
        else if (rb.velocity.y < -MaxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -MaxSpeed);
        }
    }
    void Boundaries(float x, float y)
    {
        if (transform.position.x <= -x)
        {
            transform.position = new Vector2(-x, transform.position.y);
        }
        else if (transform.position.x >= x)
        {
            transform.position = new Vector2(x, transform.position.y);
        }

        if (transform.position.y <= -y)
        {
            transform.position = new Vector2(transform.position.x, -y);
        }
        else if (transform.position.y >= y)
        {
            transform.position = new Vector2(transform.position.x, y);
        }
    }
}
