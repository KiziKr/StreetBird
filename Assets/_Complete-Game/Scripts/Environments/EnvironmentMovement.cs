using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour 
{
	[SerializeField] private float speedMove = 3.55f;

	float timer;

	void Start()
	{
		timer = Time.time + 5f;
	}
		
	void Update ()
	{
		transform.Translate (Vector3.left * speedMove * Time.deltaTime);

		if (timer <= Time.time)
		{
			Destroy (gameObject);
		}
	}
}
