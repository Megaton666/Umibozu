using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public GameObject shark;
    public GameObject enemyShadow;
    public GameObject powerup;
    public GameObject squid;
    public GameObject cliff;
    public int spawnthresh;

    private Vector3 center = new Vector3(0, 1, 0);
    private float timestamp;
    //private float cooldown;

	void Start () {
        //cooldown = Random.Range(0.5f, 2.0f);
	}
	
	//void FixedUpdate () {
 //       if (Time.time >= timestamp)
 //       {
 //           int randNum = Random.Range(0 , 100);
 //           if (randNum < spawnthresh)
 //           {
 //               SpawnSharkRandom();
 //           }
 //           else
 //           {
 //               SpawnCrateRandom();
 //           }
 //           timestamp = Time.time + cooldown;
 //           cooldown = Random.Range(0.5f, 2.0f);
 //       }
	//}

     
    Vector3 RandomCircle(Vector3 center, float radius) {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius* Mathf.Sin(ang* Mathf.Deg2Rad);
        pos.y = (center.y + radius* Mathf.Cos(ang* Mathf.Deg2Rad)) / 1.7f + 1;
        pos.z = center.z;
        return pos;
    }

    public void SpawnShark(float ang, float radius)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = (center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad)) / 1.7f + 1;
        pos.z = center.z;
        Vector3 dest = new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pos);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(shark, pos, rot).transform;
    }

    public void SpawnSharkRandom(float radius)
    {
        Vector3 pos = RandomCircle(center, radius);
        Vector3 dest = new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pos);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(shark, pos, rot).transform;
    }

    public void SpawnSharkTutorial(float ang, float radius)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = (center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad)) / 1.7f + 1;
        pos.z = center.z;
        Vector3 dest = new Vector3(0, 3, 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pos);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(shark, pos, rot).transform;
    }

    public void SpawnCrate(float x)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        Vector3 pos = new Vector3(x , 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(powerup, pos, rot).transform;
    }

    public void SpawnCrateRandom()
    {
        Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(powerup, pos, rot).transform;
    }

    public void SpawnSquid(float x)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        Vector3 pos = new Vector3(x, 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(squid, pos, rot).transform;
    }

    public void SpawnSquidRandom()
    {
        Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(squid, pos, rot).transform;
    }

    public void SpawnCliffs(float x, int amount)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(x, 7);
            Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
            Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(cliff, pos, rot).transform;
            x += cliff.GetComponent<BoxCollider2D>().size.x;
        }
    }

    public void SpawnCliffsRandom(int amount)
    {
        float x = Random.Range(-8.0f, 8.0f);
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(x, 7);
            Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
            Instantiate(enemyShadow, pos, rot).transform.parent = Instantiate(cliff, pos, rot).transform;
            x += cliff.GetComponent<BoxCollider2D>().size.x;
        }
    }

}
