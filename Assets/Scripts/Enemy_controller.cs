using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{

    private Transform playerPos;
    public float speed;
    public int health = 1;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        // this here gets our main characters position and the way how its done is by getting the GameObject named "Player" this player was initialized in unitys tag.
    }


    void Update() 
    {
        float speed_of_enemy = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed_of_enemy);       // making the character move towards to the players position in the given speed.
        // Vector2 is geting the direction to calculate.

        if(health <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Bullet"){
            health--;
        }

    }

}
