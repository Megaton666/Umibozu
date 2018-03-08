using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMenu : MonoBehaviour {

    public AudioClip batteryReload;
    public AudioClip PowerupSound;
    public AudioClip RepairSound;
    public AudioClip LightSound;
    public AudioClip airhorn;
    public Image BatteryUI;
    public Image RepairUI;
    public Image FlashlightUI;
    public Image SirenUI;
    public GameObject lightStandard;
    public GameObject lightWide;

    private GameObject siren;
    private GameObject Searchlight;
    private AudioSource audiosource;
    private bool[] inventory;
    void Start()
    {
        inventory = new bool[] { false, false, false, false };
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        Searchlight = GameObject.Find("Searchlight");
        lightStandard.SetActive(true);
        lightWide.SetActive(false);
        siren = GameObject.FindGameObjectWithTag("Siren");
        siren.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (inventory[0])
            {
                BatteryUI.GetComponent<PowerupSwitch>().SwitchOnOff(false);
                ChargeBattery();
                inventory[0] = false;
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (inventory[1])
            {
                audiosource.PlayOneShot(RepairSound, 1.5f);
                RepairUI.GetComponent<PowerupSwitch>().SwitchOnOff(false);
                StartCoroutine(RepairKit());
                inventory[1] = false;
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (inventory[2])
            {
                audiosource.PlayOneShot(LightSound, 1.5f);
                FlashlightUI.GetComponent<PowerupSwitch>().SwitchOnOff(false);
                StartCoroutine(SearchlightAngle());
                inventory[2] = false;
            }
        }
        if (Input.GetKeyDown("4"))
        {
            if (inventory[3])
            {
                audiosource.PlayOneShot(airhorn, 2.0f);
                SirenUI.GetComponent<PowerupSwitch>().SwitchOnOff(false);
                StartCoroutine(ActivateSiren());
                inventory[3] = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {;
            DestroyObject(other);
            audiosource.PlayOneShot(PowerupSound, 2.5f);
            int charge = other.gameObject.GetComponent<BoxController>().charge;
            if (!inventory[charge])
            {
                inventory[charge] = true;
                if (charge == 0) BatteryUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
                else if (charge == 1) RepairUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
                else if (charge == 2) FlashlightUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
                else SirenUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
            }
            else
            {
                if (charge == 0)
                {
                    ChargeBattery();
                }
            }
        }
    }
    IEnumerator ActivateSiren()
    {
        siren.SetActive(true);
        yield return new WaitForSeconds(5);
        siren.SetActive(false);
    }

    IEnumerator SearchlightAngle()
    {
        lightStandard.SetActive(false);
        lightWide.SetActive(true);
        yield return new WaitForSeconds(5);
        lightStandard.SetActive(true);
        lightWide.SetActive(false);
    }

    IEnumerator RepairKit()
    {
        PlayerController PlayerScript = GetComponent<PlayerController>();
        int Health = PlayerScript.Health;
        int MaxHealth = PlayerScript.MaxHealth;
        for (int i = Health; i < MaxHealth; i++) 
        {
            PlayerScript.MaxSpeed = 0;
            yield return new WaitForSeconds(0.5f);
            PlayerScript.MaxSpeed = PlayerScript.MaxSpeedInit;
            PlayerScript.Health++;
        }
        PlayerScript.MaxSpeed = PlayerScript.MaxSpeedInit;
    }

    void ChargeBattery()
    {
        Searchlight.GetComponent<SearchlightOnOff>().battery = 100;
        audiosource.PlayOneShot(batteryReload, 1.5f);
    }

    Vector3 ScaleObjectX(Vector3 input, float scale)
    {
        return new Vector3((input.x * scale), input.y, input.z);
    }
}
