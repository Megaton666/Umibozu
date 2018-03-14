using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Light aura;
    public GameObject WASD;
    public GameObject LMB;
    public GameObject RMB;
    public GameObject harpoonTut;
    public GameObject lightTut;
    public GameObject warningTut;
    public GameObject crateTut;
    public GameObject abilityTut;
    public GameObject batTut;
    public GameObject repTut;
    public GameObject flashTut;
    public GameObject sirenTut;
    public GameObject escTut;
    public GameObject story1;
    public GameObject story2;
    public GameObject story3;
    public GameObject story4;
    public Object endgameMusic;
    public Object shadow2;
    public Object shadowFinal;
    public Object eye;
    public AudioClip story1sound;
    public AudioClip story2sound;
    public AudioClip story3sound;
    public AudioClip story4sound;
    public AudioClip growl;
    public float level1Time;
    public float level2Time;
    public float level3Time;
    public float level4Time;
    public int level;


    private bool tutorial;
    private new RemoteZoom camera;
    private AudioSource audiosource;
    private ObjectSpawn spawner;
    private float startOfLevel;
    private float timestamp;
    private float cooldown;
    void Start ()
    {
        audiosource = GameObject.FindGameObjectWithTag("SFX Manager").GetComponents<AudioSource>()[1];
        camera = GameObject.Find("Main Camera").GetComponent<RemoteZoom>();
        startOfLevel = Time.time;
        spawner = GameObject.FindGameObjectWithTag("Spawn").GetComponent<ObjectSpawn>();
        tutorial = ToBool(PlayerPrefs.GetInt("Tutorial", 1));
        if (level == 1 && tutorial) StartCoroutine(Tutorial());
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
                if (Time.time - startOfLevel >= level1Time)
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
                if (randNum < 50)
                {
                    spawner.SpawnSharkRandom(15);
                }
                else if (randNum >= 50 && randNum < 80)
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
            if (Time.time - startOfLevel >= level2Time)
            {
                StartCoroutine(SecondScene());
                level = 0;
            }
        }
        else if (level == 3)
        {
            if (Time.time >= timestamp)
            {
                int randNum = Random.Range(0, 100);
                if (randNum < 35)
                {
                    spawner.SpawnSharkRandom(15);
                }
                else if (randNum >= 35 && randNum < 60)
                {
                    spawner.SpawnSquidRandom();
                }
                else if (randNum >= 60 && randNum < 70)
                {
                    spawner.SpawnCrateRandom();
                }
                else if (randNum >= 70 && randNum < 90)
                {
                    spawner.SpawnCliffsRandom(Random.Range(1, 3));
                }
                else
                {
                    spawner.SpawnGlowingCliffsRandom(Random.Range(1, 3));
                }
                timestamp = Time.time + cooldown;
                cooldown = Random.Range(0.5f, 2.0f);
            }

            if (aura.cookieSize > 9)
            {
                aura.cookieSize -= 0.01f;
            }
            if (Time.time - startOfLevel >= level3Time)
            {
                StartCoroutine(ThirdScene());
                level = 0;
            }
        }
        else if (level == 4)
        {
            if (Time.time >= timestamp)
            {
                int randNum = Random.Range(0, 100);
                if (randNum < 40)
                {
                    spawner.SpawnSharkRandom(15);
                }
                else if (randNum >= 40 && randNum < 80)
                {
                    spawner.SpawnSquidRandom();
                }
                else if (randNum >= 80 && randNum < 85)
                {
                    spawner.SpawnCrateRandom();
                }
                else if (randNum >= 85 && randNum < 95)
                {
                    spawner.SpawnCliffsRandom(Random.Range(1, 3));
                }
                else
                {
                    spawner.SpawnGlowingCliffsRandom(Random.Range(1, 3));
                }
                timestamp = Time.time + cooldown;
                cooldown = Random.Range(0.5f, 1.5f);
            }

            if (aura.cookieSize > 6.5)
            {
                aura.cookieSize -= 0.01f;
            }
            if (Time.time - startOfLevel >= level4Time)
            {
                StartCoroutine(FinalScene());
                level = 0;
            }
        }
    }

    bool ToBool(int number)
    {
        if (number == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(3);
        WASD.SetActive(true);
        yield return new WaitForSeconds(5);
        WASD.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        LMB.SetActive(true);
        yield return new WaitForSeconds(5);
        LMB.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        RMB.SetActive(true);
        yield return new WaitForSeconds(5);
        RMB.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        harpoonTut.SetActive(true);
        lightTut.SetActive(true);
        yield return new WaitForSeconds(2);
        spawner.SpawnSharkTutorial(65, 15);
        yield return new WaitForSeconds(5);
        harpoonTut.SetActive(false);
        lightTut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        warningTut.SetActive(true);
        yield return new WaitForSeconds(5);
        warningTut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        crateTut.SetActive(true);
        spawner.SpawnCrate(-3, 0);
        yield return new WaitForSeconds(7f);
        crateTut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        abilityTut.SetActive(true);
        yield return new WaitForSeconds(6);
        abilityTut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        batTut.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        batTut.SetActive(false);
        repTut.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        repTut.SetActive(false);
        flashTut.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        flashTut.SetActive(false);
        sirenTut.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        sirenTut.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        escTut.SetActive(true);
        yield return new WaitForSeconds(5f);
        escTut.SetActive(false);
        yield return new WaitForSeconds(5f);
        story1.SetActive(true);
        audiosource.PlayOneShot(story1sound);
        yield return new WaitForSeconds(story1sound.length);
        story1.SetActive(false);
        tutorial = false;
        cooldown = Random.Range(1.5f, 3.5f);
        startOfLevel = Time.time;
    }

    IEnumerator FirstScene()
    {
        yield return new WaitForSeconds(15);
        Vector3 pointOfOrigin = new Vector3(10, -7, 0);
        Vector3 dest = new Vector3(0, 0, 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pointOfOrigin);
        Instantiate(shadow2, pointOfOrigin, rot);
        camera.Zoom(5.4f);
        yield return new WaitForSeconds(3f);
        audiosource.PlayOneShot(growl, 1.0f);
        yield return new WaitForSeconds(5f);
        story2.SetActive(true);
        audiosource.PlayOneShot(story2sound);
        yield return new WaitForSeconds(story2sound.length);
        story2.SetActive(false);
        level = 2;
        startOfLevel = Time.time;
    }
    IEnumerator SecondScene()
    {
        yield return new WaitForSeconds(15);
        Vector3 pointOfOrigin = new Vector3(-10, 1, 0);
        Vector3 dest = new Vector3(0, 0, 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pointOfOrigin);
        Instantiate(shadow2, pointOfOrigin, rot);
        camera.Zoom(5.8f);
        yield return new WaitForSeconds(3f);
        audiosource.PlayOneShot(growl, 2.0f);
        yield return new WaitForSeconds(5f);
        story3.SetActive(true);
        audiosource.PlayOneShot(story3sound);
        yield return new WaitForSeconds(story3sound.length);
        story3.SetActive(false);
        level = 3;
        startOfLevel = Time.time;
    }

    IEnumerator ThirdScene()
    {
        yield return new WaitForSeconds(15);
        Vector3 pointOfOrigin = new Vector3(0, -6, 0);
        Vector3 dest = new Vector3(0, 6, 0);
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, dest - pointOfOrigin);
        Instantiate(shadow2, pointOfOrigin, rot);
        camera.Zoom(6.2f);
        yield return new WaitForSeconds(2f);
        audiosource.PlayOneShot(growl, 3.0f);
        yield return new WaitForSeconds(5f);
        story4.SetActive(true);
        audiosource.PlayOneShot(story4sound);
        yield return new WaitForSeconds(story4sound.length);
        story4.SetActive(false);
        level = 4;
        startOfLevel = Time.time;
    }

    IEnumerator FinalScene()
    {
        yield return new WaitForSeconds(15);
        camera.Zoom(6.6f);
        yield return new WaitForSeconds(1);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0;
        GameObject.Find("Main Camera").GetComponents<AudioSource>()[1].volume = 0;
        Instantiate(endgameMusic);
        yield return new WaitForSeconds(3);
        Instantiate(shadowFinal);
        yield return new WaitForSeconds(3);
        Instantiate(eye, new Vector3(4.5f, 4, 0), new Quaternion(0, 0, 0, 0)) ;
        Instantiate(eye, new Vector3(-4.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        audiosource.PlayOneShot(growl, 4.0f);
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync("Cut to black", LoadSceneMode.Single);
    }
}