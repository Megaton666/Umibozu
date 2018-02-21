using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenu : MonoBehaviour {

    public AudioClip batteryReload;
    public AudioClip PowerupSound;

    private AudioSource audiosource;
    private bool[] inventory;
    void Start()
    {
        inventory = new bool[] { false, false, false, false };
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (inventory[0])
            {
                ChargeBattery();
                inventory[0] = false;
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (inventory[1])
            {
                
                StartCoroutine(RepairKit());
                inventory[1] = false;
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (inventory[2])
            {

                inventory[2] = false;
            }
        }
        if (Input.GetKeyDown("4"))
        {
            if (inventory[3])
            {

                inventory[3] = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {;
            DestroyObject(other);
            audiosource.PlayOneShot(PowerupSound, 1.5f);
            int randNum = Random.Range(0, 2);
            if (!inventory[randNum])
            {
                inventory[randNum] = true;
            }
            else
            {
                if (randNum == 0)
                {
                    ChargeBattery();
                }
            }
        }
    }
    IEnumerator PowerUpTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator RepairKit()
    {
        PlayerController PlayerScript = GetComponent<PlayerController>();
        int Health = PlayerScript.Health;
        int MaxHealth = PlayerScript.MaxHealth;
        for (int i = Health; i < MaxHealth; i++) 
        {
            PlayerScript.MaxSpeed = 0;
            yield return new WaitForSeconds(1);
            PlayerScript.MaxSpeed = PlayerScript.MaxSpeedInit;
            PlayerScript.Health++;
        }
        PlayerScript.MaxSpeed = PlayerScript.MaxSpeedInit;
    }

    void ChargeBattery()
    {
        GameObject.Find("Searchlight").GetComponent<SearchlightOnOff>().battery = 100;
        audiosource.PlayOneShot(batteryReload, 1.5f);
    }
}
