using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GiftEntity : NetworkBehaviour
{
    private GiftButton button;
    private string[] giftsList = new string[5] {"Rocket", "IEM", "Refuel", "Boost", "Shield"};

    void Start()
    {
        button = GameObject.Find("GiftButton").GetComponent<GiftButton>();
    }

    [ClientRpc]
    public void deleteGift() {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if (other is BoxCollider) 
        {
            button?.SetGift(giftsList[Random.Range(0, 4)]);
            deleteGift();
        }
    }
}
