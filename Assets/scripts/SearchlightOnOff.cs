using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchlightOnOff : MonoBehaviour {

    public AudioClip sound;
    public GameObject Light;
    public Slider batteryBar;
    public float battery;

    private bool IsOn;
    private AudioSource audiosource;
	void Start () {
        audiosource = GetComponent<AudioSource>();
        batteryBar.maxValue = battery;
        IsOn = false;
        Light.SetActive(false);
    }
	
	void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.timeScale > 0)
        {
            TurnOnOff();
        }
    }
    void FixedUpdate()
    {
        batteryBar.value = battery;
        if (IsOn)
        {
            battery -= 0.1f;
            if (battery <= 0)
            {
                TurnOnOff();
            }
        }
        else if (battery < 25)
        {
            battery += 0.01f;
        }
    }

    void TurnOnOff()
    {
        if (!IsOn && battery >= 0)
        {
            IsOn = true;
            audiosource.pitch = 1.2f;
            audiosource.PlayOneShot(sound);
            Light.SetActive(true);
        }
        else
        {
            audiosource.pitch = 1.0f;
            IsOn = false;
            audiosource.PlayOneShot(sound);
            Light.SetActive(false);
        }
    }
}
