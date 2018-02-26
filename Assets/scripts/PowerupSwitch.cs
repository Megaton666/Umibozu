using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupSwitch : MonoBehaviour {

    public Sprite On;
    public Sprite Off;

    private bool IsOn;
	void Start () {
	}

    public void SwitchOnOff(bool command)
    {
        if (command)
        {
            GetComponent<Image>().sprite = On;
        }
        else
        {
            GetComponent<Image>().sprite = Off;
        }
    }

}
