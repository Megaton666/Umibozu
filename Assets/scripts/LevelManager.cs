using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Text instructions;
    public Light aura;
    public Image WASD;
    public Image LMB;
    public Image RMB;
    public Image harpoonTut;
    public Image lightTut;
    public Image warningTut;
    public Image crateTut;
    public Image abilityTut;
    public Image batTut;
    public Image repTut;
    public Image flashTut;
    public Image sirenTut;
    public Image escTut;
    public Object endgameMusic;
    public Object shadow2;
    public Object shadowFinal;
    public Object eye;
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
                else if (randNum >= 35 && randNum < 70)
                {
                    spawner.SpawnSquidRandom();
                }
                else if (randNum >= 70 && randNum < 80)
                {
                    spawner.SpawnCrateRandom();
                }
                else if (randNum >= 80 && randNum < 90)
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

            if (aura.cookieSize > 6)
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
        WASD.enabled = true;
        yield return new WaitForSeconds(5);
        WASD.enabled = false;
        yield return new WaitForSeconds(0.5f);
        LMB.enabled = true;
        yield return new WaitForSeconds(5);
        LMB.enabled = false;
        yield return new WaitForSeconds(0.5f);
        RMB.enabled = true;
        yield return new WaitForSeconds(5);
        RMB.enabled = false;
        yield return new WaitForSeconds(0.5f);
        harpoonTut.enabled = true;
        lightTut.enabled = true;
        yield return new WaitForSeconds(2);
        spawner.SpawnSharkTutorial(65, 15);
        yield return new WaitForSeconds(5);
        harpoonTut.enabled = false;
        lightTut.enabled = false;
        yield return new WaitForSeconds(0.5f);
        warningTut.enabled = true;
        yield return new WaitForSeconds(5);
        warningTut.enabled = false;
        yield return new WaitForSeconds(0.5f);
        crateTut.enabled = true;
        spawner.SpawnCrate(-3, 0);
        yield return new WaitForSeconds(7f);
        crateTut.enabled = false;
        yield return new WaitForSeconds(0.5f);
        abilityTut.enabled = true;
        yield return new WaitForSeconds(6);
        abilityTut.enabled = false;
        yield return new WaitForSeconds(0.5f);
        batTut.enabled = true;
        repTut.enabled = true;
        flashTut.enabled = true;
        sirenTut.enabled = true;
        yield return new WaitForSeconds(8f);
        batTut.enabled = false;
        repTut.enabled = false;
        flashTut.enabled = false;
        sirenTut.enabled = false;
        yield return new WaitForSeconds(0.5f);
        escTut.enabled = true;
        yield return new WaitForSeconds(5f);
        escTut.enabled = false;
        yield return new WaitForSeconds(5f);
        instructions.text = "17th February, 1891: \n We have entered the sea of the Umibōzu … There are sharks everywhere, the biggest sharks I have ever seen. They look like they could swallow the boat whole.";
        yield return new WaitForSeconds(8f);
        instructions.text = " ";
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
        instructions.text = "20th February, 1891: \n ”We haven’t seen the sun for days now. The fog grows thicker and thicker for every day. We must be getting close.“ ";
        yield return new WaitForSeconds(8f);
        instructions.text = " ";
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
        instructions.text = "25th February, 1891: \n “We are now far from land and these waters are deep, yet giant cliffs seem to appear out of nowhere. Not only dangerous cliffs are in these deep waters but also the largest squids ever known to man. Lucky, I brought my harpoon.”";
        yield return new WaitForSeconds(8f);
        instructions.text = " ";
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
        instructions.text = "1st March, 1891: \n “In the beginning I thought the growling was just in my head, but the sound now keeps me awake at night. Yesterday I saw a large shadow move past in the water, larger than anything I’ve seen so far. I wonder If I will live to tell the tale of the Umibozu.”";
        yield return new WaitForSeconds(8f);
        instructions.text = " ";
        level = 4;
        startOfLevel = Time.time;
    }

    IEnumerator FinalScene()
    {
        yield return new WaitForSeconds(15);
        camera.Zoom(6.6f);
        yield return new WaitForSeconds(3);
        Instantiate(shadowFinal);
        yield return new WaitForSeconds(3);
        Instantiate(eye, new Vector3(4.5f, 4, 0), new Quaternion(0, 0, 0, 0)) ;
        Instantiate(eye, new Vector3(-4.5f, 4, 0), new Quaternion(0, 0, 0, 0));
        audiosource.PlayOneShot(growl, 4.0f);
        yield return new WaitForSeconds(1);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0;
        Instantiate(endgameMusic);
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync("Cut to black", LoadSceneMode.Single);
    }
}