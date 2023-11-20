using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_controller : MonoBehaviour
{

    public Transform playerPos;
    public float speed;
    public int health = 1;                              //this creates the health of the enemy
    public static int enemyPoints=100;

    public void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        // this here gets our main characters position and the way how its done is by getting the GameObject named "Player" this player was initialized in unitys tag.
    }


    public void Update() 
    {
        float speed_of_enemy = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed_of_enemy);       // making the character move towards to the players position in the given speed.
        // Vector2 is geting the direction to calculate.

        if(health <= 0){
            Destroy(gameObject);
            Debug.Log("ENEMY DEAD");
        }
    }

    public void OnTriggerEnter2D(Collider2D col){      //
        if(col.tag == "Bullet"){                        //if the tag that enemt collides with is "Bullet" it will decreese the health of the enemy. 
            health--;
            PointManager.currentPoint+=enemyPoints;                           
        }
    }

    public static void DestroyEnemy(){
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        // DESTROY IMMEDIATE DOESNOT DESTROY GAME OBJECTTT
    }
}
