using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : MonoBehaviour
{
    public enum BulletType
    {
        normal,
        fire,
        poison
    }
    //public GameObject[] cards;
    public List<GameObject> cards = new List<GameObject>();
    public GameObject[] bulletPrefabs;
    public float numShots = 1;
    public BulletType bulletType = BulletType.normal;
    public float speed = 8;
    public GameObject cardHand;
    public CardMod cardMod;

    public void Start()
    {
        // int i = 0;
        // while(cardHand.transform.GetChild(i).childCount != 0 || i>10)
        // {
        //     Debug.Log(cardHand.transform.GetChild(i).gameObject.name);
        //     cards.Add(cardHand.transform.GetChild(i).gameObject);
        //     i++;
        // }
        // cardMod.cards
    }
}
