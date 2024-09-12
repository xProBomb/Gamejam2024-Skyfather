using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAttack : GunAttack
{
    public override void Fire(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = currentPos.up * speed;
    }
}
