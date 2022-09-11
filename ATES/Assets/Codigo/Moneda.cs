using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{

	private Collider2D _collider;
	private SpriteRenderer _rederer;
	
	
	private void Awake()
	{
		_rederer = GetComponent<SpriteRenderer>();
		_collider = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
		
	        _rederer.enabled = false;
			Destroy(gameObject, 2f);
			GameController.Score += 15;
		}
	}
}