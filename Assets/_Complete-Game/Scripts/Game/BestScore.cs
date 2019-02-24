using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScore : MonoBehaviour 
{
	private ScoreBase scoreBest;
	private int myScore;

	void Awake()
	{
		scoreBest = GetComponent<ScoreBase>();
	}

	void Start()
	{
		myScore = PlayerPrefs.GetInt ("scoreBest");

		if (myScore < ScoreGame.instance.myScore)
		{
			PlayerPrefs.SetInt ("scoreBest", ScoreGame.instance.myScore);
		}

		scoreBest.DisplayScore (PlayerPrefs.GetInt ("scoreBest"));
	}


}
