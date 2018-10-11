using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clayDispenser : MonoBehaviour
{
    public int shootCycleCount = 10;
    public float secondsBetweenShots = 2.0f;
    public GameObject shootFrom;
    public GameObject shootObject;

    private int shootCounter;
    private float minForce = 1300.0f;
    private float maxForce = 1700.0f;
    private float lastDispenseTime;
	private bool started = false;

    // Use this for initialization
    void Start ()
    {
        lastDispenseTime = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update ()
    {
        shootInterval();
    }

    public void startDispenser()
    {
        shootCounter = shootCycleCount;
		started = true;
    }

	public bool isEmpty()
	{
		if (!started)
		{
			return false;
		}

		if (shootCounter <= 0)
		{
			return true;
		}

		return false;
	}

    private void dispense()
    {
        updateDispenseTime();

        if (objectreferencesSet())
        {
            GameObject shootdisc = Instantiate(shootObject);
            shootdisc.transform.position = shootFrom.transform.position;
            applyForce(shootdisc);
        }
        else
        {
            print("missing Object References");
        }
    }

    private bool objectreferencesSet()
    {
        return (shootFrom != null && shootObject != null);
    }

    private void applyForce(GameObject objectToApplyTo)
    {
        Rigidbody rb = objectToApplyTo.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 dispenseVector = shootFrom.transform.forward;
            dispenseVector.x += Random.Range(-1.0f, 1.0f);
            dispenseVector.z += Random.Range(-1.0f, 1.0f);
            rb.AddForce(dispenseVector * Mathf.Lerp(minForce, maxForce, Random.Range(0.0f, 1.0f)));
        }
    }

    private void shootInterval()
    {
        if(this.shootCounter > 0 && cooldownExpired())
        {
            shootCounter--;
            dispense();
        }
    }

    private void updateDispenseTime()
    {
        lastDispenseTime = Time.realtimeSinceStartup;
    }

    private bool cooldownExpired()
    {
        return (Time.realtimeSinceStartup - this.lastDispenseTime > this.secondsBetweenShots);
    }
}
