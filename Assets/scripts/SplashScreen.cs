using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    private float startTime;
	void Start ()
    {
        startTime = Time.time;
	}
	

	void FixedUpdate ()
    {
        if (Time.time - startTime >= 7.0f)
        {
            SceneManager.LoadSceneAsync("Title screen", LoadSceneMode.Single);
        }
	}
}
