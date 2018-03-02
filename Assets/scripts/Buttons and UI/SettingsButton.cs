using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour {

    public GameObject settingsMenu;
	void Start ()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void Update()
    {

    }
    void TaskOnClick()
    {
        settingsMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
