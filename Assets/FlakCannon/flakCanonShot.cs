using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flakCanonShot : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void startDisplayingSmoke()
    {
        /*
        ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
        */
    }

    public void OnCollisionEnter(Collision collision)
    {
        //print("collision");
        //startDisplayingSmoke();
        //gameObject.SetActive(false);
    }
}
