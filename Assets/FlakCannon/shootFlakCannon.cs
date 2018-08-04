using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFlakCannon : MonoBehaviour
{
    public stationaryControll stationaryControll;
    public GameObject shotPrefab;
    public GameObject[] shootingBarrels;
    public AudioSource soundEmitter;
    public float shotCooldown = 0.2f;

    // shooting related
    private float lastShotTime = 0.0f;
    private LinkedList<GameObject> shootingBarrelsList;
    private LinkedList<GameObject>.Enumerator barrelsListEnumerator;
    private List<GameObject> bulletPool = new List<GameObject>();
    private List<GameObject>.Enumerator bulletEnumerator;
    private float shotSpeed = 4000.0f;

    // sounds
    private AudioClip[] weaponShootSounds;


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
        barrelsListEnumerator = shootingBarrelsList.GetEnumerator();

        lastShotTime = Time.realtimeSinceStartup;

        weaponShootSounds = Resources.LoadAll<AudioClip>("Sounds/FlakCannon");

        initBulletPool();
        bulletEnumerator = bulletPool.GetEnumerator();
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

        GameObject shootingBarrel = getShootingBarrel();

        if (!bulletEnumerator.MoveNext())
        {
            bulletEnumerator = bulletPool.GetEnumerator();
            bulletEnumerator.MoveNext();
        }
        if (bulletEnumerator.Current != null)
        {
            GameObject currentBullet = bulletEnumerator.Current;
            currentBullet.SetActive(false);
            currentBullet.transform.position = shootingBarrel.transform.position;
            currentBullet.transform.rotation = shootingBarrel.transform.rotation;
            resetBulletTrail();
            currentBullet.SetActive(true);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                rb.AddForce(shootingBarrel.transform.forward * shotSpeed);
            }
        }
    }

    private GameObject getShootingBarrel()
    {
        GameObject barrel = gameObject;
        if (barrelsListEnumerator.MoveNext())
        {
            barrel = barrelsListEnumerator.Current;
        }
        else
        {
            barrelsListEnumerator = shootingBarrelsList.GetEnumerator();
            if (barrelsListEnumerator.MoveNext())
            {
                barrel = barrelsListEnumerator.Current;
            }
        }

        return barrel;
    }

    private void resetBulletTrail()
    {
        TrailRenderer tr = GetComponent<TrailRenderer>();
        if (tr != null)
        {
            tr.Clear();
        }
    }

    private void playShotSound()
    {
        if (weaponShootSounds.Length > 0 && soundEmitter != null)
        {
            int rndVal = (int)Mathf.Round(Random.value * (weaponShootSounds.Length - 1));
            soundEmitter.PlayOneShot(weaponShootSounds[rndVal]);
        }
        else
        {
            if (weaponShootSounds.Length > 0)
            {
                print("no sounds found");
            }

            if (soundEmitter != null)
            {
                print("no audio source");
            }
        }
    }

    private void shootIfReadyAndCommandGiven()
    {
        if (shotCommandGiven() && shotIsReady())
        {
            shootBullet();
        }
    }

    private void initBulletPool()
    {
        // prefill Pool
        for (int i = 0; i < 20; i++)
        {
            GameObject bullet;
            if (shotPrefab != null)
            {
                 bullet = (GameObject)Instantiate(shotPrefab);
            }
            else
            {
                bullet = GameObject.CreatePrimitive(PrimitiveType.Quad);
                print("no bullet prefab available");
            }

            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
}
