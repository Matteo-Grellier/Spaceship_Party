using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftEntity : MonoBehaviour
{
    private GiftButton button;
    private string[] giftsList = new string[5] {"Rocket", "IEM", "Refuel", "Boost", "Shield"};

    void Start()
    {
        button = GameObject.Find("GiftButton").GetComponent<GiftButton>();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") 
        {
            button?.SetGift(giftsList[Random.Range(0, 4)]);
            Destroy(gameObject);
        }
    }
}
