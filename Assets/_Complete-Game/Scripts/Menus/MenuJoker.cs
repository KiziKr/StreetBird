using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJoker : MonoBehaviour 
{
	public MenuHealth menuHealth;
	public PlayerHealth playerHealth;

	void Start()
	{
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
		menuHealth = GameObject.Find ("MenuHealth").GetComponent<MenuHealth> ();
	}
	public void Yes()
	{
		GameManager.instance.EndGame (false, GameManager.GameState.Game);
		menuHealth.LooseHeart ();
		playerHealth.Resurrect ();
	}

	void No()
	{
		
	}
}
