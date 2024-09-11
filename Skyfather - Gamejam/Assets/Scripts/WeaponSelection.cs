using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public float curSlot;
    public bool errorChild;
    public GameObject weapon1;
    public GameObject weapon2;

    void Start()
    {
        curSlot = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            curSlot = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) & !errorChild) {
            curSlot = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) & !errorChild) {
            curSlot = 3;
        }
    }
}
