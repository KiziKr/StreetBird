using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum GameState
	{
	    Start,
		Game,
		Joker,
		GameOver
	}

	private GameObject spawner;
	public GameObject[] menus;

	public static GameManager instance;

	public bool GameOver { get; set; }
	public bool Second{ get; set; }

	private void Awake()
	{
		spawner = GameObject.Find ("Spawners");
		instance = this;
	}

	void Update()
	{
		if (Second == true) 
		{
			SecondChance ();
		}
	}

	public void SwitchMenuState(GameState gameState)
	{
		switch (gameState)
		{
		    case GameState.Start:
		    break;

		    case GameState.Game:
			menus [0].SetActive (false);
			menus [1].SetActive (true);
			menus [2].SetActive (false);
		    break;

		    case GameState.Joker:
			menus [0].SetActive (false);
			menus [1].SetActive (true);
			menus [2].SetActive (true);
			break;

		    case GameState.GameOver:
			menus [0].SetActive (true);
			menus [1].SetActive (false);
			menus [2].SetActive (false);
		    break;	
	    }
    }

	public void EndGame(bool gameOver, GameState gameState)
	{		
		SwitchMenuState (gameState);

		GameObject[] test = GameObject.FindGameObjectsWithTag("Environment");

		GameObject componentPlayer = GameObject.Find ("Player");


		for (int i = 0; i < test.Length; i++)
		{
			if (test [i].GetComponent<EnvironmentMovement> () != null)
			{
				if (gameOver) 
				{
					test [i].GetComponent<EnvironmentMovement> ().enabled = false;
					spawner.SetActive (false);

				}
				else
				{
				    test [i].GetComponent<EnvironmentMovement> ().enabled = true;
					spawner.SetActive (true);
				}
			}
		}
	}

	public void SecondChance()
	{

		GameObject[] componentEnvironment = GameObject.FindGameObjectsWithTag("Environment");

		for (int i = 0; i < componentEnvironment.Length; i++)
		{
			if (componentEnvironment[i].GetComponent<EnvironmentMovement> () != null)
			{
				componentEnvironment[i].transform.position =  Vector3.Lerp (transform.position, new Vector3 (transform.position.x + 2f, -4.7f, -2f), 1f);
			}
		}

		GameObject componentPlayer = GameObject.Find ("Player");
		componentPlayer.transform.position =  Vector3.Lerp (transform.position, new Vector3 (-1.202f,0.639f, -5f), 1f);

	}

	public void sese()
	{
		Second = true;
	}
}

