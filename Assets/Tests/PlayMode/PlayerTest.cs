using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System;

public class PlayerTest
{
    [Test]
    public void PlayerHealthDecreasesOnEnemyCollision()
    {
        GameObject playerObject = new GameObject();
        Player_controller playerController = playerObject.AddComponent<Player_controller>();
        Player_controller.characterHealth = 3f;

        GameObject enemyObject = new GameObject();
        Enemy_controller enemyController = enemyObject.AddComponent<Enemy_controller>();
        enemyObject.tag = "Enemy";
        enemyObject.AddComponent<BoxCollider2D>();

        GameObject healthBarObject = new GameObject();
        Image healthBar = healthBarObject.AddComponent<Image>();
        playerController.healthBar = healthBar;

        playerController.OnTriggerEnter2D(enemyObject.GetComponent<Collider2D>());

        Assert.Less(Player_controller.characterHealth, 3f);
        Assert.Less(playerController.healthBar.fillAmount, 3f);
    }
    
    [UnityTest]
    public IEnumerator BulletDestroysOnCollisionWithEnemy()
    {
        // Arrange
        GameObject bulletObject = new GameObject("Bullet");
        Bullet_controller bulletScript = bulletObject.AddComponent<Bullet_controller>();
        bulletObject.tag = "Bullet";

        GameObject enemyObject = new GameObject("Enemy");
        Collider2D enemyCollider = enemyObject.AddComponent<BoxCollider2D>();
        enemyCollider.tag = "Enemy";

        // Act
        bulletScript.OnTriggerEnter2D(enemyCollider);

        // Yield to the next frame to let Unity process the destruction
        yield return null;

        // Assert
        Assert.IsTrue(bulletObject==null); // The Bullet game object should be destroyed


    }

    [UnityTest]
    public IEnumerator BulletDestroysOnCollisionWithWall()
    {
        GameObject wallObject = new GameObject();
        Collider2D wallCollider = wallObject.AddComponent<BoxCollider2D>();

        GameObject bulletObject = new GameObject(); 
        Bullet_controller bulletController = bulletObject.AddComponent<Bullet_controller>();
        Collider2D bulletCollider = bulletObject.AddComponent<BoxCollider2D>();
        bulletCollider.tag = "Wall";


        bulletController.OnTriggerEnter2D(bulletCollider);
        // Yield to the next frame to let Unity process the destruction
        yield return null;
        Assert.IsTrue(bulletObject == null, "Bullet did not get destroyed upon collision with Wall.");
    }

    [Test]
    public void BulletDestroysAfterTime()
    {
        GameObject bulletGameObject = new GameObject();
        Bullet_controller bulletController = bulletGameObject.AddComponent<Bullet_controller>();
        bulletController.speed = 5.0f; // Set a speed for the bullet

        bulletController.Update();

        Assert.IsTrue(bulletGameObject==null, "Bullet did not get destroyed after the specified time.");
    }
}