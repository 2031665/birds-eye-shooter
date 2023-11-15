using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_controller : MonoBehaviour
{

    public Rigidbody2D rigid_body;

    public Animator animator;
    
    public GameObject GameOverUI;

    public Image healthBar;
    public static float characterHealth=3f;
    // public static int maxHealth = 3;

    private void Start(){

    }

    private void OnTriggerEnter2D(Collider2D col){      //
        if (col.tag=="Enemy"){                      
            characterHealth--;
            healthBar.fillAmount = characterHealth/3f;
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            Debug.Log("Health: " + characterHealth);        
            if(characterHealth <= 0){
                GameIsOver();
            }                          
        }
    }
    public void GameIsOver(){
        GameOverUI.SetActive(true);
        GameOver.isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log(GameOver.isGameOver);
    }
}

