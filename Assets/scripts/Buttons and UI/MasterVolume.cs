using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour {


	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        if (AudioListener.volume != PlayerPrefs.GetFloat("masterVolume", 1.0f))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("masterVolume", 1.0f);
        }
	}
}
