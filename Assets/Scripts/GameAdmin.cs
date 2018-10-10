using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		
	}

	public void startRound()
	{
		Highscore.resetHighScore();
		//SceneManager.LoadScene("gameScene");
	}
}
