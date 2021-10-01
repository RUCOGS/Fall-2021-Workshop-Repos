using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public GameObject Player;

    public float SpawnRadius;

    public int SpawnTime;

    // Timer to keep track of when to spawn an enemy
    private Stopwatch spawnStopwatch = new Stopwatch();
    
    // Start is called before the first frame update
    void Start()
    {
        spawnStopwatch.Start();
    }

    private void Update()
    {

        // When time is reached, spawn enemy, and restart timer.
        if (spawnStopwatch.ElapsedMilliseconds > SpawnTime)
        {
            spawnStopwatch.Restart();
            SpawnEnemy();
            
        }
        
        
    }


    
    void SpawnEnemy()
    {
        // Spawn an enemy and set the target towards the player.
        GameObject clonedEnemy = Instantiate(EnemyPrefab);
        
        // Spawn an enemy in a random location inside a circle.
        // Random.insideUnitCircle basically gives you a random position inside a circle with a radius of 1
        // Multiply it by any value to adjust the size.
        clonedEnemy.transform.position = Random.insideUnitCircle * SpawnRadius;
        
        clonedEnemy.GetComponent<Enemy>().player = Player.transform;
    }
}
