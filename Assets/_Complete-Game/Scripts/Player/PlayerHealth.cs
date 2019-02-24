using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	public int  health = 3;

	public bool isDead { get; set; }

	private Quaternion _deadRotation = Quaternion.Euler(0, 0, -90f);


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.parent.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy") 
		{
			if (col.gameObject.name == "Platform" || col.gameObject.name == "Ralenti")
				ResetGravity (true);
			
			if (!isDead) Death();
		}
	}

	private void Death()
	{
		isDead = true;
		transform.rotation = _deadRotation;

		PlayerController component = GetComponent<PlayerController> ();
		component.enabled = false;

		GameManager.instance.EndGame (true, GameManager.GameState.GameOver);	
	}

	public void Resurrect()
	{
		isDead = false;
		ResetGravity (false);

		PlayerController component = GetComponent<PlayerController> ();
		component.enabled = true;
	}

	public void ResetGravity(bool isKinematic) 
	{
		Rigidbody2D component = GetComponent<Rigidbody2D> ();
		component.velocity = Vector2.zero;
		component.isKinematic = isKinematic;
	}
}
