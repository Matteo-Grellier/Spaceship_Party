using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private Camera _mainCamera;

    private Renderer _renderer;

    private Ray _ray;
    private RaycastHit _hit;

    private int _myLayerMask = 1 << 6;

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

        // vertical overshoot of the cursor
        if (mousePoint.y < 100) // bottom
        {
            mousePoint.y = 100;
        }
        if (mousePoint.y > 410) // top
        {
            mousePoint.y = 410;
        }

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
