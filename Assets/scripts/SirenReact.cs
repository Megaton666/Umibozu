using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenReact : MonoBehaviour {

    private GameObject player;
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	
	void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag("Siren"))
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}