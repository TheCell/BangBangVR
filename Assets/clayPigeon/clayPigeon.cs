using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clayPigeon : MonoBehaviour
{
    public AudioSource soundEmitter;
    public AudioClip[] pigeonDestroySounds;

    private float destroyTimer = 2.2f;

    public void Start()
    {
        pigeonDestroySounds = Resources.LoadAll<AudioClip>("Sounds/clayPigeon");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody parentRB = gameObject.GetComponent<Rigidbody>();
        playDestroySound();

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

            rb.AddExplosionForce(300.0f, collision.transform.position, 5.0f);

            Destroy(child.gameObject, destroyTimer);
        }

        transform.DetachChildren();
        Destroy(gameObject);
    }

    private void playDestroySound()
    {
        if (pigeonDestroySounds.Length > 0 && soundEmitter != null)
        {
            int rndVal = (int)Mathf.Round(Random.value * (pigeonDestroySounds.Length - 1));
            soundEmitter.PlayOneShot(pigeonDestroySounds[rndVal]);
        }
        else
        {
            if (pigeonDestroySounds.Length > 0)
            {
                print("no sounds found");
            }

            if (soundEmitter != null)
            {
                print("no audio source");
            }
        }
    }
}
