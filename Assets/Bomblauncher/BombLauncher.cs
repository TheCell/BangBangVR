using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    
    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void setAnglesTo(Vector3 eulerAngles)
    {
        transform.eulerAngles = eulerAngles;
    }

    public void setAnglesFromNormed(Vector3 normedAngles)
    {
        //float stepSizeDegree = 1.0f / 360.0f;
        float stepSizeDegree = 45.0f / 1.0f;
        Vector3 eulerAngles = Vector3.zero;
        eulerAngles.x = stepSizeDegree * normedAngles.x;
        eulerAngles.y = stepSizeDegree * normedAngles.y;
        eulerAngles.z = stepSizeDegree * normedAngles.z;

        setAnglesTo(eulerAngles);
    }
}
