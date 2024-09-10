using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float _enemySpeed = 1.0f;

    [SerializeField]
    private float _rotationSpeed = 1.0f;

    private Rigidbody2D _enemyRigidbody;
    private enemyAIController _enemyAIController;

    private Vector2 _moveDirection;

    void Awake()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _enemyAIController = GetComponent<enemyAIController>();
    }

    void FixedUpdate()
    {
        UpdateDirection();
        FaceTarget();
        Move();
    }
    
    private void UpdateDirection()
    {
        if (_enemyAIController.AwareoOfPlayer)
        {
            _moveDirection = _enemyAIController.DirectionToPlayer;
        }
        else
        {
            _moveDirection = Vector2.zero;
        }
    }

    private void FaceTarget()
    {
        if (_moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void Move()
    {
        if (_moveDirection != Vector2.zero)
        {
            _enemyRigidbody.velocity = _moveDirection * _enemySpeed;
        }
        else
        {
            _enemyRigidbody.velocity = Vector2.zero;
        }
    }

}
