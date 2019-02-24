using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour 
{
	//FIELDS
	private float _strenght = 380f;
	private Quaternion _flyRotation;
	private Quaternion _fallRotation;
	private Vector2 _vector;

	//COMPONENTS
	private Rigidbody2D _rb2d;
	private AudioSource _audioSource;
	[SerializeField] private AudioClip audioJump, audioScore;


	private void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D> ();
		_audioSource = GetComponent<AudioSource>();
	}

	void Start ()
	{
		_vector = new Vector2 (0,-10f);

		_flyRotation = Quaternion.Euler(0, 0, 25f);
		_fallRotation = Quaternion.Euler(0, 0, -35f);
	}

	void FixedUpdate()
	{
		Animating(_rb2d.velocity.magnitude);
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Fly ();
		} 
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "TriggerScore")
		{
			ScoreGame.instance.UpScore(1);
			_audioSource.PlayOneShot (audioScore);
		}
	}

	private void Fly()
	{
		_audioSource.PlayOneShot (audioJump);
		_rb2d.velocity = Vector2.zero;
		_rb2d.AddForce (Vector2.up * _strenght);
	}
		
	private void Animating(float magnitude)
	{
		if (magnitude <= 7.8f)
		{
			transform.rotation = Quaternion.Lerp (transform.rotation, _flyRotation, 0.15f);
		} 
		else
		{
			transform.rotation = Quaternion.Lerp (transform.rotation, _fallRotation, 0.15f);
		}
	}
}
