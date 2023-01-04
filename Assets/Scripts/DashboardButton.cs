using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DashboardButton : DashboardController
{   
    public GameObject btn;
    private bool isClick = false;
    private bool isDown = false;
    private Vector3 savePos;
    private float timeElapsed;
    public float lerpDuration = 3;
    private float time;

    void Start()
    {
        savePos = btn.transform.position;
    }
    void OnMouseDown()
    {
        isClick = true;
    }
    void MoveDown()
    {
        btn.transform.position = Vector3.Lerp(btn.transform.position, new Vector3(savePos.x, -(gameObject.transform.localScale.x*0.0175f), savePos.z), timeElapsed / lerpDuration);
        timeElapsed += Time.deltaTime;
    }
    void MoveUp()
    {
        btn.transform.position = Vector3.Lerp(btn.transform.position, new Vector3(savePos.x, savePos.y, savePos.z), timeElapsed / lerpDuration);
        timeElapsed += Time.deltaTime;
    }
    void FixedUpdate()
    {
        if(isClick)
        {
            if(!isDown)
            {
                MoveDown();
                if (timeElapsed > lerpDuration)
                {
                isDown = true;
                timeElapsed = 0;
                }
            } 
            else
            {
                MoveUp();
                if (timeElapsed > lerpDuration)
                {
                isClick = false;  
                isDown = false;
                timeElapsed = 0;
                }
            }
            if (timeElapsed > lerpDuration)
            {
                isDown = true;
                
                timeElapsed = 0;           
        }
        }
    }
}
