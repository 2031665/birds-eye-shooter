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
}
