using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBase : MonoBehaviour 
{
	public Sprite[] scoreSprite = new Sprite[10];
	public GameObject[] scoreGameObject = new GameObject[3];

    public void Start()
    {
        
    }

    public void DisplayScore(int newScore)
	{
		int unite = newScore % 10;
		int dizaine = newScore / 10 % 10;
		int centaine = newScore / 100 % 10;

		if (newScore < 10)
		{
			scoreGameObject [0].GetComponent<Image> ().sprite = scoreSprite  [unite];
		}

		if (newScore >= 10) 
		{
			scoreGameObject [1].SetActive(true);
			scoreGameObject [0].GetComponent<Image> ().sprite = scoreSprite  [dizaine];
			scoreGameObject [1].GetComponent<Image> ().sprite = scoreSprite [unite];
		}

		if (newScore  >= 100) 
		{
			scoreGameObject [2].SetActive (true);
			scoreGameObject [0].GetComponent<Image> ().sprite = scoreSprite  [centaine];
			scoreGameObject [1].GetComponent<Image> ().sprite = scoreSprite [dizaine];
			scoreGameObject [2].GetComponent<Image> ().sprite = scoreSprite  [unite];
		}
	}
}
