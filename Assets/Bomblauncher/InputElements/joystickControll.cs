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
            print("originPoint " + originPoint);
        }

        if (joystickLimiterDisk != null)
        {
            float diameter = Mathf.Abs(joystickLimiterDisk.transform.localScale.x);
            maximumDisplacement = diameter / 2;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (joystick != null)
        {
            joystickXYPosition = joystick.transform.localPosition;
            clampJoystickToLimiterDisk();
        }
    }

    private void clampJoystickToLimiterDisk()
    {
        joystickXYPosition = joystickXYPosition - originPoint;
        joystickXYPosition.y = 0.0f;
        joystick.transform.localPosition = Vector3.ClampMagnitude(joystickXYPosition, maximumDisplacement) + originPoint;
    }

    public Vector2 getNormedXYDisplacement()
    {
        Vector2 displacement = new Vector2(joystickXYPosition.x, joystickXYPosition.z);
        float maxNormedValue = 1 / maximumDisplacement;
        displacement.x = displacement.x * maxNormedValue;
        displacement.y = displacement.y * maxNormedValue;
        return displacement;
    }
}
