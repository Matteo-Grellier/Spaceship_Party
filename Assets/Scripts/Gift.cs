using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public string name = "Objet";
    public bool isUsed = false;

    public void Use() {
        isUsed = true;
        Debug.Log("VOUS VENEZ D'UTILISER " + name + "!");
    }
}
