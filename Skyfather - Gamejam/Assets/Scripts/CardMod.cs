using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMod : MonoBehaviour
{
    public float curCard;
    public float handSize;
    public GameObject[] cards;
    public GameObject cardMod;

    void Start()
    {
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
                if (curCard >= cards.Length - 1)
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
                    curCard = cards.Length - 1;
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
