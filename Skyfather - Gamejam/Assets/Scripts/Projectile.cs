using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1;
    public bool tick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHp enemyHp = collision.GetComponent<EnemyHp>();
            enemyHp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


    private void Awake()
    {
        Destroy(gameObject, 3.0f);
    }
}
