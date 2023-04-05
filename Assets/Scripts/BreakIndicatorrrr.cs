using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakIndicatorrrr : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isBreak = true;
    public GameObject img;
    private void Start() {
        img.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (isBreak){
            img.SetActive(true);
        } else{
            img.SetActive(false);
        }
    }
}
