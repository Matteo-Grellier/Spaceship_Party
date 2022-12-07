using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    //-----{ MOUSE DRAG }-----------------------------------------------------------------------------------------------------------

    private Vector3 mOffset;

    private float mZCoord;
    private float mXCoord;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mXCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).x;

        // Store offset = gameobject world position - mouse world position
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        mousePoint.x = mXCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }





    //-----{ VERTICAL OVERSHOOT OF THE CURSOR }-------------------------------------------------------------------------------------

    private float speedValue;

    private float minSpeed = -.35f;
    private float maxSpeed = .35f;


    // return the speed of the motors according to the "cursor object"
    public float GetSpeedValue()
    {
        return speedValue;
    }


    // Change the Quaternion values depending on the values of the Sliders
    private static Quaternion Change(float x, float y, float z)
    {
        return new Quaternion(x, y, z, 1);
    }


    void OnMouseDrag()
    {
        //-----{ BOTTOM }----------------------------------------------------------------------
        if (GetMouseWorldPos().z <= minSpeed)
        {
            // moves "cursor object" according to the position of the "mouse cursor"
            gameObject.transform.rotation = Change(
                                                    gameObject.transform.rotation.x,
                                                    gameObject.transform.rotation.y,
                                                    minSpeed
                                                  );

            // give "minSpeed" to influence "speedValue"
            speedValue = minSpeed;

            // unlock "cursor object" for the opposite direction
            if (GetMouseWorldPos().z >= minSpeed)
            {
                gameObject.transform.rotation = Change(
                                                        gameObject.transform.rotation.x,
                                                        gameObject.transform.rotation.y,
                                                        GetMouseWorldPos().z
                                                      );
            }
        }
        //-----{ TOP }-------------------------------------------------------------------------
        else if (GetMouseWorldPos().z >= maxSpeed)
        {
            // moves "cursor object" according to the position of the "mouse cursor"
            gameObject.transform.rotation = Change(
                                                    gameObject.transform.rotation.x,
                                                    gameObject.transform.rotation.y,
                                                    maxSpeed
                                                  );

            // give "maxSpeed" to influence "speedValue"
            speedValue = maxSpeed;

            // unlock "cursor object" for the opposite direction
            if (GetMouseWorldPos().z <= maxSpeed)
            {
                gameObject.transform.rotation = Change(
                                                        gameObject.transform.rotation.x,
                                                        gameObject.transform.rotation.y,
                                                        GetMouseWorldPos().z
                                                      );
            }
        }
        //-----{ BETWEEN TWO }-----------------------------------------------------------------
        else
        {
            // moves "cursor object" according to the position of the "mouse cursor"
            gameObject.transform.rotation = Change(
                                                    gameObject.transform.rotation.x,
                                                    gameObject.transform.rotation.y,
                                                    GetMouseWorldPos().z
                                                  );

            // give z position of "cursor object" to influence "speedValue"
            speedValue = gameObject.transform.rotation.z;
        }

        Debug.Log("SpeedValue : " + speedValue);
    }
}
