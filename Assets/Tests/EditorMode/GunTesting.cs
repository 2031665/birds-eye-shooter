using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GunTesting
{
    // A Test behaves as an ordinary method
    [Test]
    public void ShootMethod_CalledOnLeftMouseClick()
    {

        Gun gun = new GameObject().AddComponent<Gun>();
        gun.bullet = new GameObject(); // Assign a GameObject to the bullet field for simplicity in testing.
        gun.cross = new GameObject();
    
        
        PauseMenu.isGamePaused = false;
        GameOver.isGameOver = false;
        gun.mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Debug.Log("X position of mouse: "+Input.mousePosition.x);
        Debug.Log("Y position of mouse: "+Input.mousePosition.y);
        
        GameObject barrelGameObject = new GameObject();
        gun.barrel = barrelGameObject.transform;

        gun.Update(); // Simulate an update (not paused, not game over)
        gun.shoot(); // Simulate left mouse click


        Bullet_controller bullet = GameObject.FindObjectOfType<Bullet_controller>();
        Assert.IsNotNull(bullet, "Bullet should be instantiated on left mouse click.");

        // // Check bullet position and rotation
        // Assert.AreEqual(gun.barrel.position, bullet.transform.position, "Bullet should be at the barrel's position.");
        // Assert.AreEqual(gun.barrel.rotation, bullet.transform.rotation, "Bullet should have the same rotation as the barrel.");

        // // Check crosshair position
        // Assert.AreEqual(gun.mousePosition.x, gun.cross.transform.position.x, 0.01f, "Crosshair X position should be updated based on mouse position.");
        // Assert.AreEqual(gun.mousePosition.y, gun.cross.transform.position.y, 0.01f, "Crosshair Y position should be updated based on mouse position.");

        // // Check gun direction adjustment
        // Vector2 targetDirection = gun.mousePosition - (Vector2)gun.transform.position;
        // Assert.AreEqual(targetDirection.normalized, gun.transform.right, "Gun direction should be adjusted to point towards the mouse position.");

        // // Simulate the game being paused
        // PauseMenu.isGamePaused = true;
        // gun.Update(); // Try shooting while paused
        // Assert.IsNull(GameObject.FindObjectOfType<Bullet_controller>(), "No bullet should be instantiated when the game is paused.");

        // // Resume the game
        // PauseMenu.isGamePaused = false;
    }
}
