using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public int tutorial;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }
    void TaskOnClick()
    {
        PlayerPrefs.SetInt("Tutorial", tutorial);
        SceneManager.LoadSceneAsync("Main game", LoadSceneMode.Single);
    }
}
