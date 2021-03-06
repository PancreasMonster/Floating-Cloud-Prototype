﻿using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScipt : MonoBehaviour
{
    public bool gameOver;
    public Text text;
    
    public AudioSource youwin;
    public AudioSource backTrack;
    private bool playingSfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && playingSfx == false)
        {
            youwin.Play();
            backTrack.Stop();
            playingSfx = true;
        }
        
        if (gameOver && Input.GetButtonDown("XboxRB"))
        {
            SceneManager.LoadScene("Map 1");
        }
    }

    public void Player1Win ()
    {
        if (!gameOver) {
            gameOver = true;
            text.text = "Player 1 has won. Press R1 to restart.";
        }
    }

    public void Player2Win()
    {
        if (!gameOver)
        {
            gameOver = true;
            text.text = "Player 2 has won. Press R1 to restart.";
        }
    }
}
