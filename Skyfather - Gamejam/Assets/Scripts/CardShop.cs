using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShop : MonoBehaviour
{
    public GameObject shop;
    public GameObject[] allCards;
    public GameObject[] cards;
    public GameObject[] choosenCards;
    void Start()
    {
        if(allCards.Length > 0)
        {
            for(int i = 0; i < 3; i++) {
                int randomIndex = Random.Range(0, allCards.Length);

                GameObject shopCard = allCards[randomIndex];
                choosenCards[i] = shopCard;

                GameObject spawnedCard = Instantiate(shopCard);

                spawnedCard.transform.SetParent(cards[i].transform, false);

                spawnedCard.transform.localScale = new Vector3(10f, 10f, 0f);
                spawnedCard.transform.localPosition = new Vector3(0f, -3, 0f);
                spawnedCard.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            shop.SetActive(!shop.activeSelf);
        }
    }

    public void NewShopCard()
    {
        for(int i = 0; i < 3; i++) {
            if(cards[i].transform.childCount < 2)
            {
                Debug.Log("this never works");
                int randomIndex = Random.Range(0, allCards.Length);
                GameObject shopCard = allCards[randomIndex];

                choosenCards[i] = shopCard;
                GameObject spawnedCard = Instantiate(shopCard);

                spawnedCard.transform.SetParent(cards[i].transform, false);

                spawnedCard.transform.localScale = new Vector3(10f, 10f, 0f);
                spawnedCard.transform.localPosition = new Vector3(0f, -3, 0f);
                spawnedCard.transform.localRotation = Quaternion.identity;
                i = 3;
            }
        }
    }
}
