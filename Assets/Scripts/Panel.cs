using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private bool IsUp;
    private bool OnMoov = false;
    private Vector3 savePos;
    private Vector3 saveSize;
    [SerializeField] private float sizeALaMano = 280;
    private float t = 0.125f;
    public bool isBroken = true;
    public GameObject breakIndicator;
    public GameObject breakIndicatorKey;
    public GameObject breakIndicatorGauge;
    public GameObject breakIndicatorFuseLeft;
    public GameObject breakIndicatorFuseRight;
    private bool isWaiting = false;
    public bool isKey = true;
    public bool isGauge = true;
    public bool isFuseLeft = true;
    public bool isFuseRight = true;
    
    // Start is called before the first frame update
    void Start() {
        savePos = transform.position;
        breakIndicator.SetActive(false);
    }
    void FixedUpdate() {
        if (OnMoov){
            if (!IsUp) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(savePos.x, savePos.y+sizeALaMano, savePos.z), t);
                isBroken = false;
            } else {
                transform.position = Vector3.Lerp(transform.position, new Vector3(savePos.x, savePos.y-sizeALaMano, savePos.z), t);
            }
            if (transform.position.y >= savePos.y+sizeALaMano - 0.125f){
                t = 0.125f;
                OnMoov = false;
                IsUp = true;
            } else if (transform.position.y <= savePos.y - sizeALaMano){
                t = 0.125f;
                OnMoov = false;
                IsUp = false;
            }
            if (t+0.0125f<=1){
                t += 0.0125f;
            }
            if (t+0.0125f>1){
                t = 1f;
            }
        } 

        //break indicator
        if (isBroken){
            if (!isWaiting){
                breakIndicator.SetActive(!breakIndicator.active);
                isWaiting = true;
                StartCoroutine(wait());   
            }
        } else{
            breakIndicator.SetActive(false);
        }
        if (isKey){
            isBroken = false;
            breakIndicatorKey.SetActive(true);
        }
        if (isGauge)
            isBroken = false;
            breakIndicatorGauge.SetActive(true);
        if (isFuseLeft){
            isBroken = false;
            breakIndicatorFuseLeft.SetActive(true);
        }
        if (isFuseRight){
            breakIndicatorFuseRight.SetActive(true);
            isBroken = false;
        }
        if (!isKey) {
            breakIndicatorKey.SetActive(false);
        }
        if(!isGauge) {
            breakIndicatorGauge.SetActive(false);
        } 
        if (!isFuseLeft){
            breakIndicatorFuseLeft.SetActive(false);
        }
        if (!isFuseRight){
            breakIndicatorFuseRight.SetActive(false);
        }
    }
    public void Displacement()
    {
        t = 0.125f;
        savePos = transform.position;
        OnMoov = true;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        isWaiting = false;
    }
}
