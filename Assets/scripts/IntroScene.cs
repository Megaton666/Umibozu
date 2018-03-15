using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour {

    public AudioClip story;

    private float startTime;
	void Start ()
    {
        startTime = Time.time;
        GetComponent<AudioSource>().PlayOneShot(story, 2.5f);
	}
	

	void Update ()
    {
		if (Time.time - startTime >= story.length)
        {
            SceneManager.LoadScene("Main game", LoadSceneMode.Single);
        }
	}
}
