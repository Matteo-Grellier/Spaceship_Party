using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public string name;
    public bool isUsed = false;

    public void Use() {
        switch (name)
        {
            case "Rocket":
                Debug.Log(name + " launched!");
                break;
            case "IEM":
                Debug.Log(name + " exploded!");
                break;
            case "Refuel":
                Debug.Log(" Your batteries is now full!");
                break;
            case "Boost":
                Debug.Log(" Speed up!");
                break;
            case "Shield":
                Debug.Log(" You are now protect with a shield!");
                break;
            default:
                break;
        }
        isUsed = true;
    }
}
