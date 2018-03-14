﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {


	void Start () {
		
	}
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Player").GetComponent<PlayerController>().Health != 0)
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }
}
