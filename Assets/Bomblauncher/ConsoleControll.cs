using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleControll : MonoBehaviour
{
    public joystickControll joystickControlls;
    public handleControll handleControlls;
    public LaunchButtonControlls launchButtonControlls;
    public GameObject bombLauncher;
    public GameObject bomb;
    public GameObject launchPoint;
    public float minimumTimeBetweenBombs = 5.0f;

    private float timeSinceLastBomb;
    private bool wasTurnedOffInbetween = true;
    private float launchForce = 10000.0f;

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
}
