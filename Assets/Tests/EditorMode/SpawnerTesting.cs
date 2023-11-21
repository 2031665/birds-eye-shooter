using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnerTesting
{
   [Test]
    public void EnemyPrefabInstantiatedAtSpawnPoint()
    {
        Spawner_controller spawner = new GameObject().AddComponent<Spawner_controller>(); // Create an instance of Spawner_controller
        spawner.enemyPrefab = new GameObject(); // Assign a dummy GameObject as the enemyPrefab
        spawner.spawnPoints = new Transform[] { new GameObject().transform }; // Create a dummy Transform as a spawn point
        spawner.interval = 2.0f;

        Debug.Log("number of spawners: " + spawner.spawnPoints.Length);
        
        spawner.Start();
        GameObject instantiatedEnemy = Object.FindObjectOfType<GameObject>();
        Assert.NotNull(instantiatedEnemy, "Enemy prefab should be instantiated");
        Assert.AreEqual(spawner.spawnPoints[0].position, instantiatedEnemy.transform.position, "Enemy should be instantiated at the spawn point");
    }
    [Test]
    public void EnemyPrefabNotInstantiatedWithoutSpawnPoints()
    {
        Spawner_controller spawner = new GameObject().AddComponent<Spawner_controller>(); 
        spawner.spawnPoints = new Transform[] { }; // No spawn points

        Debug.Log("number of spawners: " + spawner.spawnPoints.Length);

        spawner.Start();

        GameObject instantiatedEnemy = GameObject.FindGameObjectWithTag("Enemy");
        Assert.IsNull(instantiatedEnemy, "Enemy prefab should not be instantiated without spawn points");
    }
}
