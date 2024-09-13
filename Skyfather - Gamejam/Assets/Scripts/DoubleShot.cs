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
        playerShoot.numShots += 2;
    }

    public override void Drop()
    {
        playerShoot.numShots -= 1;
    }
}
