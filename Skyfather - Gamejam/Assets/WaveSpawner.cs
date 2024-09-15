using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private int waveCount = 0;
    public int enemiesAlive = 0;
    private int enemiesPerWave = 5;
    private int enemiesPerWaveIncrease = 2; // Number of enemies to add per wave
    private float enemiesPerWaveIncreaseExponential = 0.7f; // Exponential increase factor for enemies per wave
    public float enemiesThisWave = 5;

    public GameObject[] enemySpanwers;

    public GameObject[] enemyPrefabs;

    private void FixedUpdate()
    {
        CountEnemies();
        // if there are 10% or less enemies alive, spawn a new wave
        if (enemiesAlive <= enemiesThisWave * 0.1f)
        {
            SpawnWave();
            enemiesThisWave = enemiesPerWave * waveCount + enemiesPerWaveIncrease * waveCount + (enemiesPerWave * waveCount + enemiesPerWaveIncrease * waveCount) * enemiesPerWaveIncreaseExponential;
        }
    }

    private void SpawnWave()
    {
        waveCount++;
        for (int i = 0; i < enemiesThisWave; i++)
        {
            // Randomly select an enemy prefab
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            // Instantiate the enemy at a random position
            Vector3 spawnPosition = enemySpanwers[Random.Range(0, enemySpanwers.Length)].transform.position;
            // add some randomness to the spawn position
            spawnPosition.x += Random.Range(-10f, 10f);
            spawnPosition.y += Random.Range(-10f, 10f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void CountEnemies()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }


    public int GetWaveCount()
    {
        return waveCount;
    }
}
