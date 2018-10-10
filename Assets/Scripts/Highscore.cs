using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore
{
	private int highScore = 0;

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
