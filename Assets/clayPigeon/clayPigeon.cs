using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clayPigeon : MonoBehaviour
{
    private float destroyTimer = 2.2f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        foreach(Transform child in transform)
        {
            MeshCollider mc = child.GetComponent<MeshCollider>();
            mc.isTrigger = false;
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.useGravity = true;
            Destroy(child.gameObject, destroyTimer);
        }

        transform.DetachChildren();
        Destroy(gameObject);
    }
}
