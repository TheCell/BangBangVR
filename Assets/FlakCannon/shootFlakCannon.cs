using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFlakCannon : MonoBehaviour
{
    public stationaryControll stationaryControll;
    public GameObject shotPrefab;
    public GameObject[] shootingBarrels;
    public float shotCooldown = 0.2f;

    private float lastShotTime = 0.0f;
    private LinkedList<GameObject> shootingBarrelsList;
    // sounds
    private AudioClip[] weaponShootSounds;
    private AudioSource soundEmitter;

    // Use this for initialization
    void Start ()
    {
        if (shootingBarrels.Length > 0)
        {
            shootingBarrelsList = new LinkedList<GameObject>(shootingBarrels);
        }
        else
        {
            shootingBarrelsList = new LinkedList<GameObject>();
        }

        lastShotTime = Time.realtimeSinceStartup;

        weaponShootSounds = Resources.LoadAll<AudioClip>("Sounds/FlakCannon");
        soundEmitter = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        shootIfReadyAndCommandGiven();
	}

    private bool shotIsReady()
    {
        if ((lastShotTime + shotCooldown) < Time.realtimeSinceStartup)
        {
            return true;
        }

        return false;
    }

    private bool shotCommandGiven()
    {
        return stationaryControll.triggerIsActive();
    }
    
    private void shootBullet()
    {
        this.lastShotTime = Time.realtimeSinceStartup;
        playShotSound();

        /*
        arrow.transform.parent = null;
        if (this.useGravity)
        {
            arrow.GetComponent<Rigidbody>().useGravity = true;
        }
        arrow.GetComponent<Rigidbody>().velocity = Vector3.Normalize(-1.0f * arrow.transform.up) * arrowSpeedMS;
        */
    }

    private void playShotSound()
    {
        if (weaponShootSounds.Length > 0)
        {
            int rndVal = (int)Mathf.Round(Random.value * (weaponShootSounds.Length - 1));
            soundEmitter.PlayOneShot(weaponShootSounds[rndVal]);
        }
        else
        {
            print("no sounds found");
        }
    }

    private void shootIfReadyAndCommandGiven()
    {
        if (shotCommandGiven() && shotIsReady())
        {
            shootBullet();
        }
    }
}
