using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radar : MonoBehaviour
{
    // Start is called before the first frame update
    private string display;
    public GameObject ship;
    void Start()
    {
        ship.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        ship.SetActive(true);
        ship.transform.LookAt(other.gameObject.transform);
        StartCoroutine (waitFiveSecond());
    }

    IEnumerator waitFiveSecond()
    {
        yield return new WaitForSeconds(4);
        ship.SetActive(false);
    }
}
