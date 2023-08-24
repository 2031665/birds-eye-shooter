using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour
{
   private Vector2 target;
   public float speed;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);           //gets the position of the mous.
    }

    
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);  // makes the bullet move to the where the mouses last position was at the given speed.
        Destroy(gameObject, 2.0f);                  //destroys the bullet 2 seconds after it is shot.
    }

	private void OnTriggerEnter2D(Collider2D col){                      
		if(col.tag=="Wall" || col.tag =="Enemy"){                       // when the Bullet collides with the GameObjects with the tag "Wall" or "Bullet" 
            Destroy(gameObject);                                        // the bullet game object will disappear.
        }
    }	

}
