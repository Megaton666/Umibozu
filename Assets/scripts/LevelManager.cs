using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text instructions;
    public Light aura;
    public Object shadow;
    public AudioClip growl;

    private AudioSource audiosource;
    private ObjectSpawn spawner;
    private bool tutorial = true;
    private int level;
    private float startOfLevel;
    private float timestamp;
    private float cooldown;
    void Start ()
    {
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponent<AudioSource>();
        startOfLevel = Time.time;
        level = 1;
        spawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<ObjectSpawn>();
        if (level == 1) StartCoroutine(Tutorial());
        instructions.text = "";
    }


    void FixedUpdate()
    {
        if (level == 1)
        {
            if (!tutorial)
            {
                if (Time.time >= timestamp)
                {
                    int randNum = Random.Range(0 , 100);
                    if (randNum < 80)
                    {
                        spawner.SpawnSharkRandom(15);
                    }
                    else
                    {
                        spawner.SpawnCrateRandom();
                    }
                    timestamp = Time.time + cooldown;
                    cooldown = Random.Range(1.5f, 3.0f);
                }

                if (aura.cookieSize > 16)
                {
                    aura.cookieSize -= 0.01f;
                }
                if (Time.time - startOfLevel >= 60)
                {
                    StartCoroutine(FirstScene());
                    level = 0;
                }
            }

        }
        else if(level == 2)
        {
            if (Time.time >= timestamp)
            {
                int randNum = Random.Range(0, 100);
                if (randNum < 70)
                {
                    spawner.SpawnSharkRandom(15);
                }
                else if (randNum >= 70 && randNum < 80)
                {
                    spawner.SpawnSquidRandom();
                }
                else if (randNum >= 80 && randNum < 95)
                {
                    spawner.SpawnCrateRandom();
                }
                else
                {
                    spawner.SpawnCliffsRandom(Random.Range(1, 3));
                }
                timestamp = Time.time + cooldown;
                cooldown = Random.Range(1.5f, 3.0f);
            }

            if (aura.cookieSize > 12)
            {
                aura.cookieSize -= 0.01f;
            }
            if (Time.time - startOfLevel >= 60)
            {
                StartCoroutine(SecondScene());
                level = 0;
            }
        }
        else if (level == 3)
        {

        }
        else if (level == 4)
        {

        }
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(3);
        instructions.text = "Move the boat with WASD";
        yield return new WaitForSeconds(5);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "Fire the harpoon by holding down and then releasing the left mouse button";
        yield return new WaitForSeconds(5);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "Turn the spotlight on and off by pressing the right mouse button";
        yield return new WaitForSeconds(5);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "Shine your light on hidden objects to reveal their true nature";
        yield return new WaitForSeconds(1);
        spawner.SpawnSharkTutorial(65, 15);
        yield return new WaitForSeconds(3);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "Keeping the spotlight turned on drains your battery";
        yield return new WaitForSeconds(3);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "Picking up crates grants you single-use abilities";
        spawner.SpawnCrate(-3);
        yield return new WaitForSeconds(7f);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "The ability menu shows which abilities can be used \n Press the corresponding keys to select and ability";
        yield return new WaitForSeconds(4);
        instructions.text = "";
        yield return new WaitForSeconds(0.5f);
        instructions.text = "The different abilities are, respectively, battery recharge, repair kit, increased spotlight spread, and a siren that scares away enemies";
        yield return new WaitForSeconds(5f);
        instructions.text = "";
        yield return new WaitForSeconds(5f);
        instructions.text = "Level 1";
        yield return new WaitForSeconds(3f);
        instructions.text = "";
        tutorial = false;
        cooldown = Random.Range(1.5f, 3.5f);
        startOfLevel = Time.time;
    }

    IEnumerator FirstScene()
    {
        yield return new WaitForSeconds(5f);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, new Vector3(0, 0) - new Vector3(10, -7, 0));
        Instantiate(shadow, new Vector3(10, -7, 0), rot);
        yield return new WaitForSeconds(3f);
        audiosource.PlayOneShot(growl, 2.0f);
        yield return new WaitForSeconds(7f);
        instructions.text = "Level 2";
        yield return new WaitForSeconds(3f);
        instructions.text = "";
        level = 2;
        startOfLevel = Time.time;
    }
    IEnumerator SecondScene()
    {
        yield return new WaitForSeconds(5f);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, new Vector3(0, 0) - new Vector3(-10, 1, 0));
        Instantiate(shadow, new Vector3(-10, 1, 0), rot);
        yield return new WaitForSeconds(3f);
        audiosource.PlayOneShot(growl, 3.0f);
        yield return new WaitForSeconds(7f);
        instructions.text = "Level 3";
        yield return new WaitForSeconds(3f);
        instructions.text = "";
        level = 3;
        startOfLevel = Time.time;
    }
}
