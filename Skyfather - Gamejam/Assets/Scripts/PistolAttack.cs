using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAttack : GunAttack
{
    public override void Fire(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed, float numShots, float increase)
    {
        if(numShots>1)
        {
            MultiShot(bulletPrefab, firePoint, currentPos, speed, numShots, increase);
        }
        else 
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation);
            bullet.GetComponent<Projectile>().damage += increase;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = currentPos.up * speed;
        }
    }

    private void MultiShot(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed, float numShots, float increase)
    {
        float angleStep = 10f; // Adjust this value to change the spread of the bullets
        float angle = -((numShots - 1) * angleStep) / 2; // Start angle for the first bullet

        for (int i = 0; i < numShots; i++)
        {
            // Calculate the rotation for each bullet
            Quaternion bulletRotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation * bulletRotation);
            bullet.GetComponent<Projectile>().damage += increase;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bullet.transform.up * speed;

            // Increment the angle for the next bullet
            angle += angleStep;
        }
    }

    // this is the old double shot code to shoot bullet bursts

    // private IEnumerator BurstFire(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed, float numShots)
    // {
    //     float burstDelay = 0.1f;

    //     for (int i = 0; i < numShots; i++)
    //     {
    //         // Instantiate and shoot the bullet
    //         GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation);
    //         Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
    //         bulletRigidbody.velocity = currentPos.up * speed;

    //         // Wait for the next shot in the burst
    //         yield return new WaitForSeconds(burstDelay);
    //     }
    // }
}
