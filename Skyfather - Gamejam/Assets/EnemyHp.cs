using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int health;

    private void Awake()
    {
        //find the WaveSpawner in the scene based on its tag
        WaveSpawner waveSpawner = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveSpawner>();
        health = waveSpawner.GetWaveCount() / 3; // Set health based on wave count
        if (health <= 0) health = 1; // Ensure health is at least 1
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
