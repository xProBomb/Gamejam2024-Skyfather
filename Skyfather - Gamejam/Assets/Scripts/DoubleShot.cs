using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : CardsModifiers
{
    public PlayerShoot playerShoot;
    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerShoot = player.transform.GetComponent<PlayerShoot>();
    }

    public override void PickUp()
    {
        Debug.Log(playerShoot.numShots);
        playerShoot.numShots += 1;
        Debug.Log(playerShoot.numShots);
    }

    public override void Drop()
    {
        playerShoot.numShots -= 1;
    }
}
