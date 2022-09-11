using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{   
    //Inicio declaracion de variables 
    public int totalHealth = 3;
    public RectTransform heartUI;
    public RectTransform gameOverMenu;
    public GameObject hordes;
    private Animator _animator;
    private PlayerController _controller;
    private float heartSize = 16f;
    private int health;
    private SpriteRenderer _renderer;

    private void Awake()
    {   
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();

    }
    void Start()
    {
        health = totalHealth;
    }

    
    public void AddDamage(int amount)
    {
        health = health - amount;
        //Visual feeback
        StartCoroutine("VisualFeedback");
        
        //Fin del juego
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
      
    }
    public void AddHealth(int amount)
    {
        health = health + amount; 
        //Vida al tope 
        if (health > totalHealth)
        {
            health = totalHealth;
        }
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _renderer.color = Color.white;
    }


    private void OnEnable()
    {
        health = totalHealth;
    }
    private void OnDisable()
    {
        gameOverMenu.gameObject.SetActive(true);
        hordes.SetActive(false);
        _animator.enabled = false;
        _controller.enabled = false;
        
    } 
}
