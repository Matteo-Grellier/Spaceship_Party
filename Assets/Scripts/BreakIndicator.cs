using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isBroken = true;
    public GameObject img;
    private bool isWaiting = false;
    private void Start() {
        img.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (isBroken){
            if (!isWaiting){
                img.SetActive(!img.active);
                isWaiting = true;
                StartCoroutine(wait());   
            }
        } else{
            img.SetActive(false);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        isWaiting = false;
    }
}
