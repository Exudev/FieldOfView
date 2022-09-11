using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //Inicio declaracion de variables 
    public static int Score = 0;
    public string ScoreString = "Score: ";
    public Text TextScore;
    public static GameController Gamecontroller;
    public RectTransform heartUI;
    public RectTransform gameOverMenu;
    public GameObject hordes;
    private Animator _animator;
    public GameObject player;
    private SpriteRenderer _renderer;
    public GameObject respawn;
    private PlayerController _controller;
    public Text win;
  





    // Condicional 
    void Update()
    {
        if (TextScore != null)
        {

            TextScore.text = ScoreString + Score.ToString();

        }
        if (Score >= 200)
        {
            win.gameObject.SetActive(true);
            hordes.SetActive(false);
            player.SetActive(false);
            TextScore.text = ScoreString + 200;

        }



    }
  



    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
        Gamecontroller = this;
        //David Modificacion
        win.gameObject.SetActive(false);
        Score = 0;
       
    }

    public void Reset()
    {
        
        hordes.SetActive(true);
        _animator.enabled = true;
        _controller.enabled = true;
        player.transform.position = new Vector3(-3,-0,0);

            
     }
}
