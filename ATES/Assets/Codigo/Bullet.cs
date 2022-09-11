using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Inicio declaracion de variables 
	public float speed = 2f;
	public Vector2 direction;
    private Rigidbody2D _rigidBody;
    public int damage = 1;
	public float livingTime = 3f;
	public Color initialColor = Color.white;
	public Color finalColor;
    public Color reverse;
	private SpriteRenderer _renderer;
	private float _startingTime;
    private bool _returning;

	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
	}


	void Start()
    {
		//  Guardando cuando la bala se dispara 
		_startingTime = Time.time;

		// Destruir la bala despues del tiempo
		Destroy(gameObject, livingTime);
    }

   
    void Update()
    {
		
		
		// Cambiando el color 
		float _timeSinceStarted = Time.time - _startingTime;
		float _percentageCompleted = _timeSinceStarted / livingTime;

		_renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    }
    private void FixedUpdate()
    {
        Vector2 movement = direction.normalized * speed ;
        _rigidBody.velocity = movement;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player"))
        {
            
            collision.SendMessageUpwards("AddDamage",damage );
            Destroy(gameObject);
        }
        if (_returning == true && collision.CompareTag("Enemy"))
        {
       
            collision.SendMessageUpwards("AddDamage");
            Destroy(gameObject);
        }
    }
    public void AddDamage()
    {
        _returning = true;
        direction = direction * -1f;
        _renderer.color = Color.Lerp(initialColor, reverse,1.0f);
    }
} 
