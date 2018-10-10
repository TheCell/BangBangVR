using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{
	private int highScore = 0;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void resetHighScore()
	{
		highScore = 0;
	}

	public int getHighScore()
	{
		return highScore;
	}

	public void addToHighscore(int scoreToAdd)
	{
		this.highScore += scoreToAdd;
	}
}
