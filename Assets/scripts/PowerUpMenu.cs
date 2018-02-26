using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMenu : MonoBehaviour {

    public AudioClip batteryReload;
    public AudioClip PowerupSound;
    public AudioClip airhorn;
    public Texture searchlightStandard;
    public Texture searchlightWide;
    public Image BatteryUI;
    public Image RepairUI;
    public Image FlashlightUI;
    public Image SirenUI;

    private GameObject siren;
    private GameObject Searchlight;
    private GameObject lightMask;
    private GameObject directionalLight;
    private AudioSource audiosource;
    private bool[] inventory;
    void Start()
    {
        inventory = new bool[] { false, false, false, false };
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        Searchlight = GameObject.Find("Searchlight");
        lightMask = GameObject.Find("LightMask");
        directionalLight = GameObject.Find("Directional light");
        siren = GameObject.FindGameObjectWithTag("Siren");
        siren.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (inventory[0])
            {
                audiosource.PlayOneShot(PowerupSound);
                BatteryUI.GetComponent<PowerupSwitch>().SwitchOnOff(false);
                ChargeBattery();
                inventory[0] = false;
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (inventory[1])
            {
                audiosource.PlayOneShot(PowerupSound);
                RepairUI.GetComponent<PowerupSwitch>().SwitchOnOff(false);
                StartCoroutine(RepairKit());
                inventory[1] = false;
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (inventory[2])
            {
                audiosource.PlayOneShot(PowerupSound);
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
            audiosource.PlayOneShot(PowerupSound, 1.5f);
            int randNum = Random.Range(0, 4);
            if (!inventory[randNum])
            {
                inventory[randNum] = true;
                if (randNum == 0) BatteryUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
                else if (randNum == 1) RepairUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
                else if (randNum == 2) FlashlightUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
                else SirenUI.GetComponent<PowerupSwitch>().SwitchOnOff(true);
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
    IEnumerator ActivateSiren()
    {
        siren.SetActive(true);
        yield return new WaitForSeconds(5);
        siren.SetActive(false);
    }

    IEnumerator SearchlightAngle()
    {
        lightMask.transform.localScale = ScaleObjectX(lightMask.transform.localScale, 1.5f);
        directionalLight.GetComponent<Light>().cookie = searchlightWide;
        yield return new WaitForSeconds(5);
        lightMask.transform.localScale = ScaleObjectX(lightMask.transform.localScale, 1/1.5f);
        directionalLight.GetComponent<Light>().cookie = searchlightStandard;
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
        Searchlight.GetComponent<SearchlightOnOff>().battery = 100;
        audiosource.PlayOneShot(batteryReload, 1.5f);
    }

    Vector3 ScaleObjectX(Vector3 input, float scale)
    {
        return new Vector3((input.x * scale), input.y, input.z);
    }
}
