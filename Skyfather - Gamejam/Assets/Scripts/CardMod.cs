using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMod : MonoBehaviour
{
    public float curCard;
    public float handSize;
    public List<GameObject> cards = new List<GameObject>();
    public GameObject cardMod;

    void Start()
    {
        int i = 0;
        while(cardMod.transform.GetChild(i).childCount != 0 || i>10)
        {
            cards.Add(cardMod.transform.GetChild(i).gameObject);
            i++;
        }
        Debug.Log("Prefab " + cards[0].transform.GetChild(0).gameObject.name);
        cards[0].transform.GetChild(0).GetComponent<CardsModifiers>().PickUp();
        curCard = 0;
        cards[0].transform.GetChild(0).position += new Vector3(0,1,-5);
    }

    void Update()
    {
        if(cardMod.activeSelf)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                int index = Mathf.FloorToInt(curCard);
                cards[index].transform.GetChild(0).position += new Vector3(0,-1,5);
                if (curCard >= cards.Count-1)
                {
                    curCard = 0;
                } else
                {
                    curCard++;
                }
                index = Mathf.FloorToInt(curCard);
                cards[index].transform.GetChild(0).position += new Vector3(0,1,-5);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                int index = Mathf.FloorToInt(curCard);
                cards[index].transform.GetChild(0).position += new Vector3(0,-1,5);
                if (curCard <= 0)
                {
                    curCard = cards.Count - 1;
                }
                else
                {
                    curCard--;
                }
                index = Mathf.FloorToInt(curCard);
                cards[index].transform.GetChild(0).position += new Vector3(0,1,-5);
            }
        }
    }
}
