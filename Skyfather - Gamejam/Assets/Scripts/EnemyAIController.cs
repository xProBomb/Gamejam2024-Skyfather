using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIController : MonoBehaviour
{
    public bool AwareoOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _AwarenessDistance = 5.0f;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 enemyToPlayer = _playerTransform.position - transform.position;
        DirectionToPlayer = enemyToPlayer.normalized;

        if (enemyToPlayer.magnitude < _AwarenessDistance)
        {
            AwareoOfPlayer = true;
        }
        else
        {
            AwareoOfPlayer = false;
        }
    }
}
