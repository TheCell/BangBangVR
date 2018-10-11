using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		allDispenserScripts();
		updateHighscoreBoard();
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
	
	private void updateHighscoreBoard()
	{
		GameObject highScoreText = (GameObject) GameObject.Find("HighscoreScore");
		if (highScoreText != null)
		{
			TextMesh highScoreTextMesh = highScoreText.GetComponent<TextMesh>();
			//print(Highscore.getHighScore().ToString());
			highScoreTextMesh.text = Highscore.getHighScore().ToString();
		}
	}
}
