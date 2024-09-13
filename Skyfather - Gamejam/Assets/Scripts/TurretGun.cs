using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurretGun : MonoBehaviour
{

    public float range = 10f;
    [SerializeField]
    private LayerMask targetMask;
    private Transform target;

    [SerializeField]
    private float fireDelay = 1f;
    private float fireTimer;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float bulletSpeed = 10f;

    void Update()
    {
        if (target == null)
        {
            FindTarget();
        }
        else if (target != null && Vector2.Distance(transform.position, target.position) > range)
        {
            target = null;
        }

        FaceTarget();

        if (target != null)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireDelay)
            {
                Fire();
                fireTimer = 0f;
            }
        }

    }

    private void FindTarget()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, range, Vector2.zero, 0f, targetMask);
        if (hit.Length > 0)
        {
            target = hit[0].transform;
        }
    }

    private void FaceTarget()
    {
        if (target == null) return;
        Vector2 direction = (Vector2)(target.position - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, -90f));
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = (target.position - firePoint.position).normalized * bulletSpeed;
    }
}
