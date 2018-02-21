using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
    private bool IsPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused && Time.timeScale == 0.0f)
        {
            Time.timeScale = 1;
            IsPaused = false;
            pauseMenu.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused && Time.timeScale == 1)
        {
            Time.timeScale = 0.0f;
            IsPaused = true;
            pauseMenu.SetActive(true);
        }
    }

}
