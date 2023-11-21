using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class EnemyTest
{
    [Test]
    public void EnemyHealthDecreasesOnBulletCollision()
    {
        GameObject enemyObject = new GameObject();
        Enemy_controller enemy = enemyObject.AddComponent<Enemy_controller>();

        GameObject bulletObject = new GameObject();
        bulletObject.tag = "Bullet";
        Collider2D bulletCollider = bulletObject.AddComponent<BoxCollider2D>();
        enemy.health = 1;

        enemy.OnTriggerEnter2D(bulletCollider);

        Assert.AreEqual(0, enemy.health);
    }

    [Test]
    public void EnemyMovesTowardsPlayer()
    {
        GameObject playerGameObject = new GameObject();
        playerGameObject.tag = "Player"; // Set the tag to "Player"
        Transform playerTransform = playerGameObject.transform;
        playerTransform.position = new Vector3(0, 0, 0); // Set the initial position for the player

        GameObject enemyGameObject = new GameObject();
        Enemy_controller enemy = enemyGameObject.AddComponent<Enemy_controller>();
        enemy.speed = 1f;
        enemy.playerPos = playerTransform;
        enemyGameObject.transform.position = new Vector3(5, 0, 0); // Set the initial position for the enemy

        float initialDistance = Vector2.Distance(enemyGameObject.transform.position, playerTransform.position);
       
        Debug.Log("initial position of enemy: " + enemyGameObject.transform.position);
        enemy.Update();
        Debug.Log("Positon of the player: " + enemy.playerPos.position);
        Debug.Log("UPDATED position of enemy: " + enemyGameObject.transform.position);

        float newDistance = Vector2.Distance(enemyGameObject.transform.position, playerTransform.position);
        Assert.Less(newDistance, initialDistance, "Enemy did not move towards the player.");
    }
    [Test]
    public void EnemyGivesPointAfterShot()
    {
        GameObject enemyGameObject = new GameObject();
        Enemy_controller enemyController = enemyGameObject.AddComponent<Enemy_controller>();
        enemyController.health = 0;

        GameObject bulletObject = new GameObject();
        bulletObject.tag = "Bullet";
        Collider2D bulletCollider = bulletObject.AddComponent<BoxCollider2D>();

        int newValueTest = PointManager.currentPoint+Enemy_controller.enemyPoints;
        enemyController.OnTriggerEnter2D(bulletCollider);

        


        Assert.AreEqual(PointManager.currentPoint, newValueTest, "Points should be awarded on enemy death.");
        PointManager.currentPoint = 0;

    }
}
