using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DashboardButton : DashboardController
{   
    public GameObject btn;
    public float newPosY;
    private bool isClick = false;
    private bool isDown = false;
    private Vector3 savePos;

    private float timeElapsed;
    public float lerpDuration = 3;

    void Start()
    {
        // btn = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        // Debug.Log(btn);
        // posInitY = btn.transform.position.y;
        savePos = btn.transform.position;
    }
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        isClick = true;
    }

    void MoveDown()
    {
        Debug.Log("dfghjkl");

        btn.transform.position = Vector3.Lerp(btn.transform.position, new Vector3(savePos.x, savePos.y-newPosY, savePos.z), timeElapsed / lerpDuration);
        timeElapsed += Time.deltaTime;
    }

    void MoveUp()
    {
        Debug.Log("ureueueue");

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
            } 
            else
            {
                MoveUp();
                if (timeElapsed > lerpDuration)
                {
                isClick = false;  
                }
            }
            if (timeElapsed > lerpDuration)
            {
                // isClick = false;  
                isDown = true;
                
                timeElapsed = 0;
                
            }
        }
        
    }
}

