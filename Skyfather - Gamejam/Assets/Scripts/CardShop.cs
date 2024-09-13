using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShop : MonoBehaviour
{
    public GameObject shop;
    public GameObject[] allCards;
    public GameObject[] cards;
    void Start()
    {
        if(allCards.Length > 0)
        {
            int randomIndex = Random.Range(0, allCards.Length);

            GameObject shopCard = allCards[randomIndex];

            GameObject spawnedCard = Instantiate(shopCard);

            spawnedCard.transform.SetParent(cards[0].transform, false);

            spawnedCard.transform.localPosition = Vector3.zero;
            spawnedCard.transform.localRotation = Quaternion.identity;

            Debug.Log("Placed card: " + spawnedCard.name + " in slot: " + cards[0].name);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            shop.SetActive(!shop.activeSelf);
        }
    }
}
