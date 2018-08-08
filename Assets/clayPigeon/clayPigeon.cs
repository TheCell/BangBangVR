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
        Rigidbody parentRB = gameObject.GetComponent<Rigidbody>();

        foreach (Transform child in transform)
        {
            MeshCollider mc = child.GetComponent<MeshCollider>();
            mc.isTrigger = false;
            child.gameObject.AddComponent<Rigidbody>();
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.useGravity = true;
            if (parentRB != null)
            {
                rb.angularVelocity = parentRB.angularVelocity;
                rb.velocity = parentRB.velocity;
            }
            Destroy(child.gameObject, destroyTimer);
        }

        transform.DetachChildren();
        Destroy(gameObject);
    }
}
