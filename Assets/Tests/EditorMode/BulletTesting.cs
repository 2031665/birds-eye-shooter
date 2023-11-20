using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletTesting
{
    [Test]
    public void BulletMovesTowardsTarget()
    {
        GameObject bulletGameObject = new GameObject();
        Bullet_controller bulletController = bulletGameObject.AddComponent<Bullet_controller>();
        bulletController.speed = 5.0f; // Set a speed for the bullet

        Vector2 initialPosition = new Vector2(0, 0);
        bulletGameObject.transform.position = initialPosition;

        Vector2 targetPosition = new Vector2(5, 0); // Set a target position

        bulletController.target = targetPosition;
        bulletController.Update();

        Vector2 newPosition = bulletGameObject.transform.position;
        Assert.AreNotEqual(initialPosition, newPosition, "Bullet did not move towards the target.");
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

    [Test]
    public void BulletDestroysOnCollisionWithWall()
    {
        GameObject bulletGameObject = new GameObject();
        Bullet_controller bulletController = bulletGameObject.AddComponent<Bullet_controller>();
        BoxCollider2D collider = bulletGameObject.AddComponent<BoxCollider2D>();
        collider.tag = "Wall"; // Set a tag for the collider

        bulletController.OnTriggerEnter2D(collider);

        Assert.AreEqual("null", bulletGameObject.ToString() , "Bullet did not get destroyed upon collision with Enemy.");
    }

    [Test]
    public void BulletDestroysOnCollisionWithEnemy()
    {
        GameObject enemyObject = new GameObject();
        Enemy_controller enemy = enemyObject.AddComponent<Enemy_controller>();

        GameObject bulletObject = new GameObject();
        Bullet_controller bulletController = bulletObject.AddComponent<Bullet_controller>();
        Collider2D bulletCollider = bulletObject.AddComponent<BoxCollider2D>();
        bulletCollider.tag = "Enemy"; 

        bulletController.OnTriggerEnter2D(bulletCollider);
        Debug.Log("object that is hit "+bulletObject);

        Assert.AreEqual("null", bulletObject.ToString() , "Bullet did not get destroyed upon collision with Enemy.");
    }
}
