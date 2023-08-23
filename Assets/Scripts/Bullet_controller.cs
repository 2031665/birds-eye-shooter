using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour
{
   private Vector2 target;
   public float speed;



    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        Destroy(gameObject, 2.0f);
    }

	private void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="Wall" || col.tag =="Enemy"){
            Destroy(gameObject);
        }
    }	

}
