using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressLevel : MonoBehaviour {

	private float startTime, minTime, maxTime;

	private Slider slider;

	void Start () 
	{
		slider = GetComponent<Slider> ();

		minTime = startTime = Time.time;
		maxTime = startTime + 30f;
		slider.minValue = minTime;	
		slider.maxValue = maxTime;	
	}

	void FixedUpdate () 
	{
		if(!GameManager.instance.GameOver)
			slider.value = Time.time;

		if (slider.value >= maxTime) 
		{
			//GameManager.instance.WinGame ();
		}
	}
}
