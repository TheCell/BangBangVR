using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Highscore
{
	private static int highScore = 0;

	public static void resetHighScore()
	{
		highScore = 0;
	}

	public static int getHighScore()
	{
		return highScore;
	}

	public static void addToHighscore(int scoreToAdd)
	{
		highScore += scoreToAdd;
	}
}
