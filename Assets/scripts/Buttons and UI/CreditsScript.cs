using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {

	
	void Start ()
    {
        StartCoroutine(TimeLimit());
	}
	

	void Update ()
    {
		if (Input.GetKeyDown("escape"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Endgame Music"));
            SceneManager.LoadSceneAsync("Title screen", LoadSceneMode.Single);
        }
	}

    IEnumerator TimeLimit()
    {
        yield return new WaitForSeconds(20);
        Destroy(GameObject.FindGameObjectWithTag("Endgame Music"));
        SceneManager.LoadSceneAsync("Title screen", LoadSceneMode.Single);
    }
}
