using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_controller : MonoBehaviour
{
    public GameObject enemyPrefab;                  //initializing the object that will be prefabed(the object that will be multi-used)
    public Transform[] spawnPoints;                 //initializes the position of the spawners. 
    public float interval;                          //initializing the break between enemy spawn times
    
    public void Start()
    {
        InvokeRepeating("spawn",0.1f, interval);    //calls the spawn method after 0.1f with the rate of the interval variable, which is 3 right now.
    }

    public void spawn() 
    {
        int randomPosition =  Random.Range(1, spawnPoints.Length);            // outputs a random value between 0 and the amount of spawnerPoints.
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomPosition].position, Quaternion.identity); // Instantiate(the object we want to create, the position that the object will be created, rotation(in this case it is default))
    }
}
