using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour {

    private Text text;
    private Slider slider;

    void Start()
    {
        text = GetComponent<Text>();
        slider = GetComponentInParent<Slider>();
    }
	void Update ()
    {
        text.text = "Volume: " + slider.value.ToString("F2");
	}
}
