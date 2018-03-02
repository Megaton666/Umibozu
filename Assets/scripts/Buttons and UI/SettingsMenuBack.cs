using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuBack : MonoBehaviour {

    private GameObject originMenu;

	void Start ()
    {
        originMenu = GetComponentInParent<SettingsMenu>().originMenu;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            originMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
	void TaskOnClick ()
    {
        originMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
	}
}
