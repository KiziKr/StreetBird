using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDisplayScore : MonoBehaviour 
{
	private Text text;

	public int monScore;

	void Start()
	{
		monScore += PlayerPrefs.GetInt ("bestScore");
		text = GetComponent<Text> ();
		text.text =monScore.ToString();
	}
}
