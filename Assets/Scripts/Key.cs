using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public int startingAngle = -45;
    private bool isStart = false;

    private void RotateKeyLeft(){
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
    private void RotateKeyRight()
    {
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, startingAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        Vibrant(true);
    }

    private void Vibrant(bool isVibrant){
        if(true){
            for (int i = 0; i < 100; i++)
            {
                transform.position += transform.forward*100;
                transform.position += transform.forward*-100;
            }
        }
    }

    public void OnEventClick(){
        isStart = !isStart;
    }

    private void FixedUpdate(){

        if (isStart) {
            RotateKeyRight();
        } else {
            RotateKeyLeft();
        }
    }
}
