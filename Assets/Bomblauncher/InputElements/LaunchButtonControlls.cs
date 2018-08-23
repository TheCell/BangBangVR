using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButtonControlls : MonoBehaviour
{
    public GameObject button;

    private Vector3 originPoint;
    private Vector3 buttonXYPosition;
    private float maximumDisplacement;

    // Use this for initialization
    void Start ()
    {
        if (button != null)
        {
            originPoint = button.transform.localPosition;
            maximumDisplacement = Mathf.Abs(button.transform.localScale.y) / 2;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (button != null)
        {
            buttonXYPosition = button.transform.localPosition;
            clampButtonToLimits();
        }
    }

    private void clampButtonToLimits()
    {
        buttonXYPosition.x = 0.0f;
        buttonXYPosition.z = 0.0f;
        button.transform.localPosition = Vector3.ClampMagnitude(buttonXYPosition, maximumDisplacement);
    }

    public bool isPressed()
    {
        float displacementValue = getNormedYDisplacement(true);
        return displacementValue < 0;
    }

    public float getNormedYDisplacement(bool midIsZero = false)
    {
        float displacement = buttonXYPosition.y;

        if (midIsZero)
        {
            float maxNormedValue = 1 / maximumDisplacement;
            displacement = displacement * maxNormedValue;
        }
        else
        {
            float maxNormedValue = 1 / (maximumDisplacement * 2);
            displacement = displacement * maxNormedValue + 0.5f;

            if (displacement < 0.0f)
            {
                displacement = 0;
            }

            if (displacement > 1.0f)
            {
                displacement = 1.0f;
            }
        }

        return displacement;
    }
}
