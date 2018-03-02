using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public GameObject shark;
    public GameObject longShadow;
    public GameObject roundShadow;
    public GameObject longCrate;
    public GameObject roundCrate;
    public GameObject squid;
    public GameObject cliff;
    public GameObject glowingCliff;

    private Vector3 center = new Vector3(0, 1, 0);

	void Start () {
	}
	

     
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
        Instantiate(longShadow, pos, rot).transform.parent = Instantiate(shark, pos, rot).transform;
    }

    public void SpawnSharkRandom(float radius)
    {
        Vector3 pos = RandomCircle(center, radius);
        Vector3 dest = new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pos);
        Instantiate(longShadow, pos, rot).transform.parent = Instantiate(shark, pos, rot).transform;
    }

    public void SpawnSharkTutorial(float ang, float radius)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = (center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad)) / 1.7f + 1;
        pos.z = center.z;
        Vector3 dest = new Vector3(0, 3, 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pos);
        Instantiate(longShadow, pos, rot).transform.parent = Instantiate(shark, pos, rot).transform;
    }

    public void SpawnCrate(float x, int crateCharge)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        Mathf.Clamp(crateCharge, 0, 3);
        Vector3 pos = new Vector3(x , 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        if (Random.Range(0, 2) == 0)
        {
            GameObject crate = Instantiate(longCrate, pos, rot);
            Instantiate(longShadow, pos, rot).transform.parent = crate.transform;
            crate.GetComponent<BoxController>().charge = crateCharge;
        }
        else
        {
            GameObject crate = Instantiate(roundCrate, pos, rot);
            Instantiate(roundShadow, pos, rot).transform.parent = crate.transform;
            crate.GetComponent<BoxController>().charge = crateCharge;
        }
    }

    public void SpawnCrateRandom()
    {
        Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        if (Random.Range(0, 2) == 0)
        {
            GameObject crate = Instantiate(longCrate, pos, rot);
            Instantiate(longShadow, pos, rot).transform.parent = crate.transform;
            crate.GetComponent<BoxController>().charge = Random.Range(0, 3);
        }
        else
        {
            GameObject crate = Instantiate(roundCrate, pos, rot);
            Instantiate(roundShadow, pos, rot).transform.parent = crate.transform;
            crate.GetComponent<BoxController>().charge = Random.Range(0, 3);
        }
    }

    public void SpawnSquid(float x)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        Vector3 pos = new Vector3(x, 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        Instantiate(longShadow, pos, rot).transform.parent = Instantiate(squid, pos, rot).transform;
    }

    public void SpawnSquidRandom()
    {
        Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 7);
        Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
        Instantiate(longShadow, pos, rot).transform.parent = Instantiate(squid, pos, rot).transform;
    }

    public void SpawnCliffs(float x, int amount)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(x, 7);
            Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
            Instantiate(roundShadow, pos, rot).transform.parent = Instantiate(cliff, pos, rot).transform;
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
            Instantiate(roundShadow, pos, rot).transform.parent = Instantiate(cliff, pos, rot).transform;
            x += cliff.GetComponent<BoxCollider2D>().size.x;
        }
    }

    public void SpawnGlowingCliffs(float x, int amount)
    {
        Mathf.Clamp(x, -8.0f, 8.0f);
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(x, 7);
            Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
            Instantiate(glowingCliff, pos, rot);
            x += cliff.GetComponent<BoxCollider2D>().size.x;
        }
    }

    public void SpawnGlowingCliffsRandom(int amount)
    {
        float x = Random.Range(-8.0f, 8.0f);
        for (int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(x, 7);
            Quaternion rot = Quaternion.FromToRotation(Vector2.zero, Vector2.zero);
            Instantiate(glowingCliff, pos, rot);
            x += cliff.GetComponent<BoxCollider2D>().size.x;
        }
    }
}
