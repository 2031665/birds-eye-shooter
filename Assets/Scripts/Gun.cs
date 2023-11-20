using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Vector3 mousePosition;                      // initializing a Vector3 to get the mouse position.
    public GameObject bullet;                           // initialized the GameObject bullet so that the prefab bullet can be added on the Unity2D UI
    public GameObject cross;                            // initialized the GameObject cross so that the cross can be added to the gun on Unity2D
    public Transform barrel;
    public float bullet_speed;

    public void Update()
    {
        if(!PauseMenu.isGamePaused && !GameOver.isGameOver){                                                                                                          // so that the gun wont shoot during the pause.
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z)); // this inbuilt ScreenToWorldPoint transforms the point from screen space to world space 

            cross.transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);                             //setting up the crosshairs position same as where the mouse is at.

            if(Input.GetMouseButtonDown(0)){    //0 here indicates left-click on the mouse
                shoot();
            }

            Vector2 targetDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);        //to get the targetDirection we subtract transform position from the mouse position

            transform.right = targetDirection; //changes the X axis to targetDirections distance
        }
    }

    public void shoot(){
       var firedBullet =  Instantiate(bullet, barrel.position, barrel.rotation);               // instantiates the bullet
    }
}
