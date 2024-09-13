using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : CardsModifiers
{
    // public GameObject bulletPrefab;
    // public float speed;
    // public float numShots;
    public PlayerShoot playerShoot;
    public override void PickUp()
    {
        Debug.Log(playerShoot.numShots);
        playerShoot.numShots += 2;
        Debug.Log(playerShoot.numShots);
    }

    public override void Drop()
    {
        playerShoot.numShots -= 1;
    }
}
