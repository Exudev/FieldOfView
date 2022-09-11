using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	[SerializeField] GameObject lightingParticles ;
	[SerializeField] GameObject burstParticles  ;
    public int life = 1;
    private Collider2D _collider;
	private SpriteRenderer _rederer;


	private void Awake() 
	{
		_rederer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) {
            //curalo
            collision.SendMessageUpwards("AddHealth", life);
            //desactivar collider
            _collider.enabled = false;

            //visual 
            _rederer.enabled = false;
			lightingParticles.SetActive(false);
			burstParticles.SetActive(true);

			Destroy(gameObject, 2f);
            GameController.Score += 10;
		}
				
	}
}
