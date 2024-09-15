using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAmmo : CardsModifiers
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
        playerShoot.numFireCard += 1;
        playerShoot.damageIncrease += 3;
    }

    public override void Drop()
    {
        playerShoot.numFireCard -= 1;
        playerShoot.damageIncrease -= 3;
    }
}
