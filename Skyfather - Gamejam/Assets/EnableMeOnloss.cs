using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMeOnloss : MonoBehaviour
{
    public GameObject objectToEnable;

    public bool gameOver = false;
    public GameObject Base;

    void Update()
    {
        if (Base == null)
        {
            // try to find the Base object in the scene
            Base = GameObject.FindGameObjectWithTag("Base");
        }
        // Check if the game is over
        if (Base.GetComponent<LoseGame>().gameOver)
        {
            objectToEnable.SetActive(true);
        }
    }
}
