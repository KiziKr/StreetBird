using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGame : MonoBehaviour 
{
	public static ScoreGame instance;
	public ScoreBase myyScore;
	public int myScore = 0;

	void Start () 
	{
		instance = this;
		myyScore = GetComponent<ScoreBase> ();
		myyScore.DisplayScore (myScore);
	}

	public void UpScore(int newScore)
	{
		myScore += newScore;
		myyScore.DisplayScore (myScore);
	}
}
