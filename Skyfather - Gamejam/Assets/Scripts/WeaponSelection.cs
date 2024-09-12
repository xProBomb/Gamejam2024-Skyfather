using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public float curSlot;
    public bool errorChild;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public Transform weaponSpawn;
    public GameObject cardHand;

    void Start()
    {
        curSlot = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            curSlot = 1;
            Instantiate(weapon1.transform.GetChild(0).gameObject, weaponSpawn.position, Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) & !errorChild) {
            curSlot = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) & !errorChild) {
            curSlot = 3;
        }
    }
}
