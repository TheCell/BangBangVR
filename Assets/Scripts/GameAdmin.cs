using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Highscore.resetHighScore();
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		allDispenserScripts();
	}

	public void startRound()
	{
		Highscore.resetHighScore();
		//SceneManager.LoadScene("gameScene");
	}

	private void allDispenserScripts()
	{
		clayDispenser[] clayDispenserScripts = FindObjectsOfType(typeof(clayDispenser)) as clayDispenser[];
		bool gameEnd = true;
		if (clayDispenserScripts.Length <= 0)
		{
			gameEnd = false;
		}

		foreach(clayDispenser dispenserScript in clayDispenserScripts)
		{
			if (!dispenserScript.isEmpty())
			{
				gameEnd = false;
			}
		}

		if (gameEnd)
		{
			SceneManager.LoadScene("IntroScene", LoadSceneMode.Single);
		}
	}
}
