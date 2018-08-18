using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleControll : MonoBehaviour
{
    public GameObject handle;
    public GameObject handleLimiterDisk;

    private Vector3 originPoint;
    private Vector3 handleXYPosition;
    private float maximumDisplacement;

    // Use this for initialization
    void Start ()
    {
        if (handle != null)
        {
            originPoint = handle.transform.localPosition;
        }

        if (handleLimiterDisk != null)
        {
            maximumDisplacement = Mathf.Abs(handleLimiterDisk.transform.localScale.z) / 2;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (handle != null)
        {
            handleXYPosition = handle.transform.localPosition;
            clampHandleToLimiterDisk();
        }
    }

    private void clampHandleToLimiterDisk()
    {
        handleXYPosition = handleXYPosition - originPoint;
        handleXYPosition.y = 0.0f;
        handleXYPosition.x = 0.0f;
        handle.transform.localPosition = Vector3.ClampMagnitude(handleXYPosition, maximumDisplacement) + originPoint;
    }

    public float getNormedXDisplacement()
    {
        float displacement = handleXYPosition.z;
        float maxNormedValue = 1 / maximumDisplacement;
        displacement = displacement * maxNormedValue;
        return displacement;
    }

    public bool isOn()
    {
        float displacementValue = getNormedXDisplacement();
        return displacementValue < 0;
    }
}
