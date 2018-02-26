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
    public GameObject projectile;
    public GameObject GameOverScreen;
    public GameObject gameOverMenu;


    private new SpriteRenderer renderer;
    private bool harpoonPrimed = false;
    private float startTime = 0.0f;
    private float harpoonChargeTime = 0.6f;
    private float rotationZ = 0f;
    private bool IsInvincible = false;
    private float Accel;
    private Rigidbody2D rb;
    private AudioSource audiosource;
    private Transform harpoon;

    [HideInInspector]
    public int Health;
    [HideInInspector]
    public float MaxSpeed;

    void Start ()
    {
        GameOverScreen.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        harpoon = transform.Find("Harpoon");
        MaxSpeed = MaxSpeedInit;
        Accel = AccelInit;
        Health = MaxHealth;
        Healthbar.maxValue = Health;
        renderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
     
        rb.velocity += new Vector2(moveHorizontal * Accel, moveVertical * Accel);
        LimitSpeed();
        ChargeHarpoon();
        TurnSideways(moveHorizontal);
        HealthbarFill();
        Boundaries(8.4f, 3.7f);
        CheckAlive();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy1") || other.gameObject.CompareTag("Enemy2")) && !IsInvincible )
        {
            TakeDamage(1);
            audiosource.PlayOneShot(EnemycollideSound, 2f);
            StartCoroutine(InvulnTimer());
        }  
    }

    void CheckAlive()
    {
        if (Healthbar.value <= 0)
        {
            GetComponent<AudioSource>().Stop();
            GameObject.Find("Main Camera").GetComponents<AudioSource>()[0].Stop();
            GameObject.Find("Main Camera").GetComponents<AudioSource>()[1].Stop();
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

    void ChargeHarpoon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            startTime = Time.time;
            audiosource.clip = HarpoonLoad;
            audiosource.Play();
        }

        if (Input.GetButton("Fire1"))
        {
            if (startTime + harpoonChargeTime <= Time.time)
                {
                if (!harpoonPrimed)
                {
                    Instantiate(projectile, harpoon.transform.position, harpoon.transform.rotation).transform.parent = harpoon.transform;
                    harpoonPrimed = true;
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            audiosource.Stop();
            if (harpoonPrimed)
            {
                harpoonPrimed = false;
            }
        }

    }
    IEnumerator InvulnTimer()
    {
        IsInvincible = true;
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.white;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.white;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.white;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.white;
        yield return new WaitForSeconds(0.25f);
        renderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        IsInvincible = false;
        renderer.color = Color.white;
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
