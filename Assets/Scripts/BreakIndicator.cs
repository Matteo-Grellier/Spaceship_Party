using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakIndicator : MonoBehaviour
{
    public bool isBroken = false;
    public Image img;
    private bool isWaiting = false;

    private void Start() 
    {
        img.enabled = false;
    }

    void FixedUpdate() 
    {
        if (isBroken)
        {
            if (!isWaiting)
            {
                img.enabled = !img.enabled;
                isWaiting = true;
                StartCoroutine(wait());   
            }
        } 
        else
        {
            img.enabled = false;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        isWaiting = false;
    }
}
