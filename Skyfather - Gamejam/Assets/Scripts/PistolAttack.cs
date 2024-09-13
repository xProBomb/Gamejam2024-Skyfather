using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAttack : GunAttack
{
    public override void Fire(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed, float numShots)
    {
        if(numShots>1)
        {
            StartCoroutine(BurstFire(bulletPrefab, firePoint, currentPos, speed, numShots));
        }
        else 
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = currentPos.up * speed;
        }
    }

    private IEnumerator BurstFire(GameObject bulletPrefab, GameObject firePoint, Transform currentPos, float speed, float numShots)
    {
        float burstDelay = 0.1f;

        for (int i = 0; i < numShots; i++)
        {
            // Instantiate and shoot the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, currentPos.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = currentPos.up * speed;

            // Wait for the next shot in the burst
            yield return new WaitForSeconds(burstDelay);
        }
    }
}
