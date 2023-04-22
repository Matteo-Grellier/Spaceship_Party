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
    public float waitTime = 1.5f;
    private float timer = 0f;

    [SerializeField] private Spaceship spaceship;
    [SerializeField] private Panel panel;


    // STOP //
    private void RotateKeyLeft()
    {
        timer = 0f; // reset time for next restart

        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }

    // START //
    private void RotateKeyRight()
    {
        // turn the key
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, startingAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);

        timer += Time.deltaTime;

        if(startingAngle >= -45 && timer < waitTime)
        {
            // shake the key
            transform.position = new Vector3(transform.position.x  + Mathf.Cos(Time.time * frequency)*amplitude, transform.position.y + Mathf.Sin(Time.time * frequency)*amplitude, transform.position.z);
        }
    }

    void Start()
    {
        dirShake = transform.forward;
        initPos = transform.position; // store this to avoid floating point error drift
    }

    public void OnEventClick()
    {
        isStart = !isStart;
    }

    private void FixedUpdate()
    {

        if(!spaceship)
        {
            spaceship = GameManager.instance.localPlayer.GetComponent<Spaceship>();
        }

        if(!isStart)
        {
            RotateKeyLeft();
            spaceship?.SetSlidersValue(0f); 
            panel.isKey = true;
        } 
        else 
        {
            panel.isKey = false;
            RotateKeyRight();
        }
    }
}
