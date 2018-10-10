using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public clayDispenser clayDispenser;
	public clayDispenser clayDispenser2;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        startDispenser();
    }

    public void OnCollisionEnter(Collision collision)
    {
        startDispenser();
    }

    public void startDispenser()
    {
        print("dispenser started");
        if (clayDispenser != null)
        {
            clayDispenser.startDispenser();

			if (clayDispenser2 != null)
			{
				clayDispenser2.startDispenser();
			}
        }
        else
        {
            print("no script reference");
        }

		// destroy start object after start
		Destroy(gameObject);
	}
}
