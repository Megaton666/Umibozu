using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutToBlack : MonoBehaviour {


	void Start () {
        StartCoroutine(Countdown());
	}
	
	IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync("Credits", LoadSceneMode.Single);
    }
}
