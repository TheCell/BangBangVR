﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{

    public GameObject rotationPointObject;

    private Vector3 rotationPoint;
    private Vector3 originPoint;

    // Use this for initialization
    void Start ()
    {
        originPoint = transform.position;

        if (rotationPointObject != null)
        {
            rotationPoint = rotationPointObject.transform.position;
        }
        else
        {
            print("no rotationpoin set!");
            rotationPoint = new Vector3(0, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void FixedUpdate()
    {
        //turnByThisStep(new Vector3(0.5f, 0.5f, 0.5f));
        turnByThisStep(new Vector3(0.5f, 0.5f, 0.5f));
    }

    public void turnByThisStep(Vector3 stepsize)
    {
        transform.Rotate(stepsize);
        //transform.position = originPoint;

        /*
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles = eulerAngles + stepsize;

        eulerAngles.x = Mathf.Clamp(eulerAngles.x, -45.0f, 45.0f);
        eulerAngles.y = Mathf.Clamp(eulerAngles.y, -45.0f, 45.0f);
        eulerAngles.z = Mathf.Clamp(eulerAngles.z, -45.0f, 45.0f);

        transform.eulerAngles = eulerAngles;
        */

        //transform.position = originPoint;
        /*
        if (Mathf.Abs(eulerAngles.x) + stepsize.x > 45.0f)
        {
            eulerAngles.x = 0.0f;
        }
        if (Mathf.Abs(eulerAngles.y) + stepsize.y > 45.0f)
        {
            eulerAngles.y = 0.0f;
        }
        if (Mathf.Abs(eulerAngles.z) + stepsize.z > 45.0f)
        {
            eulerAngles.z = 0.0f;
        }
        */

        //transform.RotateAround(rotationPoint, Vector3.up, 0.5f);

        /*
        eulerAngles.x = ClampAngle(eulerAngles.x, -45.0f, 45.0f);
        eulerAngles.y = ClampAngle(eulerAngles.y, -45.0f, 45.0f);
        eulerAngles.z = ClampAngle(eulerAngles.z, -45.0f, 45.0f);
        transform.localEulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        */
    }

    /*
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }
        return Mathf.Clamp(angle, min, max);
    }
    */
}
