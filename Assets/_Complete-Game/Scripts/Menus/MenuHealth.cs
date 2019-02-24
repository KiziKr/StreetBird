using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuHealth : MonoBehaviour
{
	private PlayerHealth playerHealth;
	public Sprite[] heart = new Sprite[2];

	void Awake()
	{
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
	}

	void Start () 
	{
		for (int i = 0; i < playerHealth.health; i++)
		{
			transform.GetChild (i).GetComponent<Image> ().sprite = heart [0];
		}	
	}

	public void LooseHeart()
	{
		int temp = playerHealth.health - 1;
		transform.GetChild (temp).GetComponent<Image> ().sprite = heart [1];
		playerHealth.health--;
	}
}
