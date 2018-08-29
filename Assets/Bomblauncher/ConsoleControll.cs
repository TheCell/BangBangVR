using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleControll : MonoBehaviour
{
    public joystickControll joystickControlls;
    public handleControll handleControlls;
    public LaunchButtonControlls launchButtonControlls;
    public BombLauncher bombLauncherScript;
    public GameObject bombLauncher;
    public GameObject bomb;
    public GameObject launchPoint;
    public float minimumTimeBetweenBombs = 5.0f;

    private float timeSinceLastBomb;
    private bool wasTurnedOffInbetween = true;
    private float maximumLaunchForce = 10000.0f;
    private float minimumLaunchForce = 3000.0f;

	// Use this for initialization
	void Start ()
    {
        timeSinceLastBomb = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (launchButtonControlls.isPressed())
        {
            launchBombIfCriteriaMet();
        }
        else
        {
            resetTurnOffBoolean();
        }
	}

    private void launchBomb()
    {
        print("peng");
        timeSinceLastBomb = Time.realtimeSinceStartup;

        GameObject bomb = spawnBomb();
        Rigidbody bombRB = bomb.GetComponent<Rigidbody>();
        if (bombRB != null)
        {
            Vector3 forceAngle = bombLauncher.transform.up;
            float launchForce = maximumLaunchForce;
            if (handleControlls != null)
            {
                launchForce = Mathf.Lerp(minimumLaunchForce, maximumLaunchForce, handleControlls.getNormedXDisplacement());
            }
            else
            {
                print("handle not set");
            }
            forceAngle = forceAngle * launchForce;
            print(forceAngle);
            bombRB.AddForce(forceAngle);
        }
    }

    private void launchBombIfCriteriaMet()
    {
        if (wasTurnedOffInbetween && enoughTimePastSinceLastLaunch())
        {
            wasTurnedOffInbetween = false;
            launchBomb();
        }
    }

    private void resetTurnOffBoolean()
    {
        wasTurnedOffInbetween = true;
    }

    private bool enoughTimePastSinceLastLaunch()
    {
        return (this.timeSinceLastBomb + minimumTimeBetweenBombs) < Time.realtimeSinceStartup;
    }

    private GameObject spawnBomb()
    {
        GameObject bomb = Instantiate(this.bomb);
        if (launchPoint != null)
        {
            bomb.transform.position = launchPoint.transform.position;
        }

        return bomb;
    }

    private void FixedUpdate()
    {
        if (joystickControlls != null && bombLauncherScript != null)
        {
            Vector2 JoystickXY = joystickControlls.getNormedXYDisplacement();
            Vector3 step = new Vector3(JoystickXY.x, 0.0f, JoystickXY.y);
            bombLauncherScript.setAnglesFromNormed(step);
        }
        else
        {
            print("joystickControlls or bombLauncher is not set");
        }
    }
}
