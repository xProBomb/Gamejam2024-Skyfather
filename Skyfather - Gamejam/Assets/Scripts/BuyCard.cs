using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCard : MonoBehaviour
{
    public GameObject cardHere;
    public GameObject player;

    public void OnCardClick()
    {
        cardHere = transform.GetChild(1).gameObject;
        if(player.transform.GetComponent<CardMod>().cards.Count < 9) {
            player.transform.GetComponent<CardMod>().AddCard(cardHere);
            Destroy(cardHere);
            StartCoroutine(DelayNewShopCard());
        }
    }

    IEnumerator DelayNewShopCard()
    {
        yield return new WaitForSeconds(0.1f);
        player.transform.GetComponent<CardShop>().NewShopCard();
    }
}
