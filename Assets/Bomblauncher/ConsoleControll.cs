using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleControll : MonoBehaviour
{
    public joystickControll joystickControlls;
    public handleControll handleControlls;
    public GameObject bombLauncher;
    public float minimumTimeBetweenBombs = 5.0f;

    private float timeSinceLastBomb;
    private bool wasTurnedOffInbetween = true;

	// Use this for initialization
	void Start ()
    {
        timeSinceLastBomb = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (handleControlls.isOn())
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
}
