using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnvironment : MonoBehaviour 
{
	[SerializeField] private float timer;
	[SerializeField] private float delayTimer;

	[SerializeField] private GameObject prefabEnvironment;

	void Update () 
	{
		Spawner ();
	}

	public void Spawner()
	{
		if (timer <= Time.time) 
		{
			timer = Time.time + delayTimer;
			GameObject gameObject = Instantiate (prefabEnvironment, transform.position, transform.rotation);

			if (gameObject.name != "Pipe(Clone)") 
				return;
			
			float newPositionY = Random.Range (-1.90f, 1.70f);
			gameObject.transform.position = new Vector2 (transform.position.x, newPositionY);
		}
	}

	public void ResetSpawner()
	{
		timer = Time.time + 1f;
	}
}

