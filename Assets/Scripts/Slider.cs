using UnityEngine;

public class Slider : MonoBehaviour
{

    public float smoothSpeed = 500f;
    private float sliderAngle = -35f;

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
        Debug.Log(GetValue());
    }

    private void RotateSlider() 
    {
        sliderAngle += Input.GetAxis("Mouse Y") * smoothSpeed * Time.deltaTime;
        sliderAngle = Mathf.Clamp(sliderAngle, -35, 39);
        gameObject.transform.rotation = Quaternion.AngleAxis(sliderAngle, Vector3.forward); // turn around x axis
    }

    public float GetValue() {
        float sliderAngleValue = (sliderAngle - (-35)) * (74 - 0) / (39 - (-35)) + 0;
        return sliderAngleValue/74;
    }
}