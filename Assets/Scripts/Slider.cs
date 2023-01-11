using UnityEngine;

public class Slider : MonoBehaviour
{

    public float smoothSpeed = 500f;
    private float sliderAngle = 0f;

    void Start() 
    {
        RotateSlider();
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
        gameObject.transform.rotation = Quaternion.AngleAxis(sliderAngle, Vector3.right); // turn around x axis
    }
}