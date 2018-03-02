using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

	
	void Start ()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("masterVolume", 1.0f);
	}
	

	void Update ()
    {
        PlayerPrefs.SetFloat("masterVolume", GetComponent<Slider>().value);
	}
}
