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

    // Start is called before the first frame update
    void Start() {
        savePos = transform.position;
    }
    void FixedUpdate() {
        if (OnMoov){
            if (!IsUp) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(savePos.x, savePos.y+sizeALaMano, savePos.z), t);
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
    }
    public void Displacement()

    {
        t = 0.125f;
        savePos = transform.position;
        OnMoov = true;
    }
}
