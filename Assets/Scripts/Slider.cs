using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private Camera _mainCamera;

    private Renderer _renderer;

    private float speedValue;

    private int minSpeed = 0;
    private int maxSpeed = 1;

    private Ray _ray;
    private RaycastHit _hit;

    private int _myLayerMask = 1 << 6;

    public float GetSpeedValue()
    {
        return speedValue;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 1000f, _myLayerMask))
            {
                if (_hit.transform == transform)
                {
                    Debug.Log("Click");
                    _renderer.material.color = _renderer.material.color == Color.red ? Color.blue : Color.red;
                }
            }
        }


        //------------------------------{ HIGHER IS HOTTER }------------------------------//

        // pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        // vertical overshoot of the cursor
        if (mousePoint.y == 50)
        {
            Debug.Log("Cold");
        }
        else if (mousePoint.y >= 237.5 && mousePoint.y < 300)
        {
            //Debug.Log("WARNING ! DANGER OF OVERHEATING !");
        }
        else if (mousePoint.y == 300)
        {
            Debug.Log("BOOM");
        }
    }


    //------------------------------{ DRAG & DROP }------------------------------//

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
        
        

        Debug.Log(gameObject.transform.position);

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        //------------------------------{ VERTICAL OVERSHOOT OF THE CURSOR }------------------------------

        //---------------{ BOTTOM }---------------
        if (gameObject.transform.position.z <= minSpeed)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, minSpeed);

            // give "minSpeed" to influence "speedValue"
            speedValue = minSpeed;

            // unlock "cursor object" for the opposite direction
            if (GetMouseWorldPos().z >= minSpeed)
            {
                gameObject.transform.position = GetMouseWorldPos() + mOffset;
            }
        }

        //---------------{ TOP }---------------
        else if (gameObject.transform.position.z >= maxSpeed)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, maxSpeed);

            // give "maxSpeed" to influence "speedValue"
            speedValue = maxSpeed;

            // unlock "cursor object" for the opposite direction
            if (GetMouseWorldPos().z <= maxSpeed)
            {
                gameObject.transform.position = GetMouseWorldPos() + mOffset;
            }
        }

        //---------------{ IN PROGRESS }---------------
        else
        {
            // moves "cursor object" according to the position of the "mouse cursor"
            gameObject.transform.position = GetMouseWorldPos() + mOffset;

            // give z position of "cursor object" to influence "speedValue"
            speedValue = gameObject.transform.position.z;
        }

        Debug.Log("SpeedValue : " + speedValue);
    }
}
