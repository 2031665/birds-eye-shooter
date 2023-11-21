using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour
{
   public Vector2 target;
   public float speed;

    public void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);           //gets the position of the mous.
    }

    
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);  // makes the bullet move to the where the mouses last position was at the given speed.
        if((Vector2)transform.position==target){
            DestroyBullet();
        }

    }

	public void OnTriggerEnter2D(Collider2D col){                      
		if(col.tag=="Wall" || col.tag =="Enemy"){                       // when the Bullet collides with the GameObjects with the tag "Wall" or "Enemy" 
            Destroy(gameObject);                                        // change with DestroyImmediate to make the test BulletDestroysOnCollisionWithWall() and BulletDestroysOnCollisionWithEnemy()
        }
    }	

    public void DestroyBullet(){
        DestroyImmediate(gameObject);                 //needs to change the Destroy function into DestroyImmediate funciton to pass the test BulletDestroysAfterTime()
    }

}
