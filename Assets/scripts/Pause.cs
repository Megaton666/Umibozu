using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
    }

}
