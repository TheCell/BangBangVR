using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public clayDispenser clayDispenser;

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
        print("collision");
        if (clayDispenser != null)
        {
            clayDispenser.startDispenser();
        }
        else
        {
            print("no script reference");
        }
    }
}
