using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnerTesting
{
   [Test]
    public void Spawn_EnemyPrefabInstantiatedAtSpawnPoint()
    {
        Spawner_controller spawner = new GameObject().AddComponent<Spawner_controller>(); // Create an instance of Spawner_controller
        spawner.enemyPrefab = new GameObject(); // Assign a dummy GameObject as the enemyPrefab
        spawner.spawnPoints = new Transform[] { new GameObject().transform }; // Create a dummy Transform as a spawn point
        spawner.interval = 2.0f;
        spawner.Start();
        GameObject instantiatedEnemy = Object.FindObjectOfType<GameObject>();
        Assert.NotNull(instantiatedEnemy, "Enemy prefab should be instantiated");
        Assert.AreEqual(spawner.spawnPoints[0].position, instantiatedEnemy.transform.position, "Enemy should be instantiated at the spawn point");
    }
}
