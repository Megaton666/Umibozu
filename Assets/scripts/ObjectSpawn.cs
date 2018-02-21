using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemyShadow;
    public GameObject powerup;
    public float radius;
    public int spawnthresh;

    private float timestamp;
    private float cooldown;

	void Start () {
        cooldown = Random.Range(0.5f, 2.0f);
	}
	
	void FixedUpdate () {
        if (Time.time >= timestamp)
        {
            int randNum = Random.Range(0 , 100);
            if (randNum < spawnthresh)
            {
                Vector3 center = new Vector3(0, 1, 0);
                Vector3 pos = RandomCircle(center, radius);
                Vector3 dest = new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0);
                Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pos);
                Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(enemy, pos, rot).transform;
            }
            else
            {
                Vector3 pos = new Vector3(Random.Range(-8.0f, 0.0f), 7);
                Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
                Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(powerup, pos, rot).transform;
            }
            timestamp = Time.time + cooldown;
            cooldown = Random.Range(0.5f, 2.0f);
        }
	}

     
    Vector3 RandomCircle(Vector3 center, float radius) {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius* Mathf.Sin(ang* Mathf.Deg2Rad);
        pos.y = (center.y + radius* Mathf.Cos(ang* Mathf.Deg2Rad)) / 1.7f + 1;
        pos.z = center.z;
        return pos;
    }
}
