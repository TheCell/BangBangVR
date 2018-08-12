using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickControll : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickLimiterDisk;

    private Vector3 originPoint;
    private Vector3 joystickXYPosition;
    private float maximumDisplacement;

	// Use this for initialization
	void Start ()
    {
        if (joystick != null)
        {
            originPoint = joystick.transform.localPosition;
        }

        if (joystickLimiterDisk != null)
        {
            float diameter = joystickLimiterDisk.transform.localPosition.x;
            maximumDisplacement = diameter / 2;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (joystick != null)
        {
            //Vector3.Distance(transform.position, joystick.transform.position);
            //joystickXYPosition = transform.position - joystick.transform.position;
        }

        print("joystickXYPosition " + joystickXYPosition);
    }
}
