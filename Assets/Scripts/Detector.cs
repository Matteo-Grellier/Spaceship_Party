using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    // Start is called before the first frame update
    private string display;
    public GameObject detectorRed;
    void Start()
    {
        detectorRed.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        print(other.gameObject.name);
        if(other.gameObject.name is "Obstacle")
        {
            detectorRed.SetActive(true);
            detectorRed.transform.LookAt(other.gameObject.transform);
            StartCoroutine(waitFiveSecond());
        }
    }

    IEnumerator waitFiveSecond()
    {
        yield return new WaitForSeconds(4);
        detectorRed.SetActive(false);
    }
}
