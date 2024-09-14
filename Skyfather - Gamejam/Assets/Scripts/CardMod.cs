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
        while(cardMod.transform.GetChild(i).childCount != 0 || i>=10)
        {
            cards.Add(cardMod.transform.GetChild(i).gameObject);
            i++;
        }
        //Debug.Log("Prefab " + cards[0].transform.GetChild(0).gameObject.name);
        //cards[0].transform.GetChild(0).GetComponent<CardsModifiers>().PickUp();
        curCard = 0;
        //cards[0].transform.GetChild(0).position += new Vector3(0,1,-5);
    }

    void Update()
    {
        if(cardMod.activeSelf && cardMod.transform.GetChild(0).childCount > 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                int index = Mathf.FloorToInt(curCard);
                cards[index].transform.GetChild(0).position += new Vector3(0,-1,5);
                if (curCard >= cards.Count-1)
                {
                    Debug.Log("got this far");
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
            if(Input.GetKeyDown(KeyCode.E))
            {
                cards[Mathf.FloorToInt(curCard)].transform.GetChild(0).GetComponent<CardsModifiers>().Drop();
                RemoveCard(Mathf.FloorToInt(curCard));
            }
        }
    }

    public void AddCard(GameObject newCard)
    {
        GameObject spawnedCard = Instantiate(newCard);
        cards.Add(cardMod.transform.GetChild(cards.Count).gameObject);
        spawnedCard.transform.GetComponent<CardsModifiers>().PickUp();
        spawnedCard.transform.SetParent(cardMod.transform.GetChild(cards.Count - 1), false);
        spawnedCard.transform.localScale = new Vector3(6f, 6f, 0f);
        if(cards.Count == 1)
        {
            Debug.Log("This is what we want");
            spawnedCard.transform.localPosition = new Vector3(0f, 1f, -5f);
        }
        else
        {
            spawnedCard.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        
    }

    public void RemoveCard(int indexToRemove)
    {
        // Remove the card from the list
        GameObject cardToRemove = cards[indexToRemove].transform.GetChild(0).gameObject;
        Destroy(cardToRemove);

        // Shift the remaining cards down
        for (int i = indexToRemove + 1; i < cards.Count; i++)
        {
            GameObject card = cards[i].transform.GetChild(0).gameObject;
            card.transform.SetParent(cardMod.transform.GetChild(i - 1), false); // Move card to the previous slot
        }

        // Remove the last card slot as it is now empty
        cards.RemoveAt(cards.Count - 1);
    }
}
