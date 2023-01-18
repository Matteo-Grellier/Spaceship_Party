using UnityEngine;

public class Slider : MonoBehaviour
{

    public float smoothSpeed = 500f;
    private float sliderAngle = 0f;

    public bool isFacingZ = false;

    void Start() 
    {
        Debug.Log(transform.rotation.y);
        //Debug.Log(transform.rotation);
        //transform.Rotate(new Vector3(0, 0, 0));
        //RotateSlider();
    }

    void OnMouseDrag()
    {
        RotateSlider();
    }

    private void RotateSlider() 
    {
        sliderAngle += Input.GetAxis("Mouse Y") * smoothSpeed * Time.deltaTime;
        Debug.Log(Input.GetAxis("Mouse Y") + " | " +  smoothSpeed + " | " + -Time.deltaTime);
        sliderAngle = Mathf.Clamp(sliderAngle, -35, 39);

        Vector3 rotationAxis;
        Vector3 rotationEulers;

        if (isFacingZ)
        {
            rotationAxis = Vector3.right;
            rotationEulers = new Vector3(0, 90, 0);
        } 
        else
        {
            rotationAxis = Vector3.forward;
            rotationEulers = new Vector3(0, 0, 0);
        }

        transform.rotation = Quaternion.AngleAxis(sliderAngle, rotationAxis); // turn around x axis
        transform.Rotate(rotationEulers);

    }
}