using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GiftEntity : NetworkBehaviour
{
    private GiftButton button;
    private string[] giftsList = new string[3] {"Refuel", "Boost", "Shield"};  //, "Rocket", "IEM"

    void Start()
    {
        button = GameObject.Find("GiftButton").GetComponent<GiftButton>();
    }

    [ClientRpc]
    public void deleteGift() 
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.isTrigger == false) 
        {
            button?.SetGift(giftsList[Random.Range(0, 3)]);
            deleteGift();
        }
    }
}
