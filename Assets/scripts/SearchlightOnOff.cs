using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchlightOnOff : MonoBehaviour {

    public Sprite ON;
    public Sprite OFF;
    public AudioClip sound;
    public GameObject Light;
    public Slider batteryBar;
    public float battery;

    private bool IsOn;
    private AudioSource audiosource;
    private SpriteRenderer sr;
	void Start () {
        audiosource = GetComponent<AudioSource>();
        batteryBar.maxValue = battery;
        IsOn = false;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = OFF;
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
        if (Input.GetButtonDown("Fire2"))
        {
            TurnOnOff();
        }
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
            //sr.sprite = ON;
            IsOn = true;
            audiosource.pitch = 1.2f;
            audiosource.PlayOneShot(sound);
            Light.SetActive(true);
        }
        else
        {
            //sr.sprite = OFF;
            audiosource.pitch = 1.0f;
            IsOn = false;
            audiosource.PlayOneShot(sound);
            Light.SetActive(false);
        }
    }
}
