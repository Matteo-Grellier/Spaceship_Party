using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public int startingAngle = -45;
    private bool isStart = false;



    private Vector3 initPos;
    private Vector3 dirShake;
    public float amplitude; // the amount it moves
    public float frequency; // the period of the earthquake



    // STOP //
    private void RotateKeyLeft(){
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
    // START //
    private void RotateKeyRight(){
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, startingAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        transform.position = initPos + dirShake*Mathf.Sin(frequency * Time.fixedDeltaTime)*amplitude;
    }

    void Start(){
        dirShake = transform.forward;
        initPos = transform.position; // store this to avoid floating point error drift
    }

    public void OnEventClick(){
        isStart = !isStart;
    }

    private void FixedUpdate(){
        if (isStart) {
            RotateKeyRight();
            Debug.Log(Time.fixedDeltaTime);
        } else {
            RotateKeyLeft();
        }
    }
}
