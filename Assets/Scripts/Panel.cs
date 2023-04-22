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
    [SerializeField] private bool isBroken = false;
    public BreakIndicator breakIndicator;
    public GameObject breakIndicatorKey;
    public GameObject breakIndicatorGauge;
    public GameObject breakIndicatorFuseLeft;
    public GameObject breakIndicatorFuseRight;
    private bool isWaiting = false;
    public bool isKey = true;
    public bool isGauge = true;
    public bool isFuseLeft = true;
    public bool isFuseRight = true;

    void Start()
    {
        savePos = transform.position;
        breakIndicator.isBroken = false;
    }

    void FixedUpdate()
    {
        if (OnMoov){
            if (!IsUp) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(savePos.x, savePos.y+sizeALaMano, savePos.z), t);
                // isBroken = false;
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

        // activate/desactivate break indicator
        if (isBroken)
            breakIndicator.isBroken = true;
        else
            breakIndicator.isBroken = false;

        // if any is activated, isBroken = true
        if (isKey || isGauge || isFuseLeft || isFuseRight)
            isBroken = true;

        // if none are activated, isBroken = false
        if (!isKey && !isGauge && !isFuseLeft && !isFuseRight)
            isBroken = false;

        // set their active property to the value of the boolean
        breakIndicatorKey.SetActive(isKey);
        breakIndicatorGauge.SetActive(isGauge);
        breakIndicatorFuseLeft.SetActive(isFuseLeft);
        breakIndicatorFuseRight.SetActive(isFuseRight);

    }

    public void Displacement()
    {
        if (!OnMoov) {
            t = 0.125f;
            savePos = transform.position;
            OnMoov = true;
        }
    }
}
