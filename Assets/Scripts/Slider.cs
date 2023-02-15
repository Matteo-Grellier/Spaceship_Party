using UnityEngine;

public class Slider : MonoBehaviour
{
    public float smoothSpeed = 500f;
    public float sliderAngle = 0f;
    public bool canBeMove = true;

    void OnMouseDrag() {
        RotateSlider();
    }

    private void RotateSlider() 
    {
        if(canBeMove){
            sliderAngle += Input.GetAxis("Mouse Y") * smoothSpeed * Time.deltaTime;
            sliderAngle = Mathf.Clamp(sliderAngle, -45, 30);

            Vector3 rotationAxis;
            Vector3 rotationEulers;

            rotationAxis = Vector3.right;
            rotationEulers = new Vector3(0, 90, 0);

            transform.rotation = Quaternion.AngleAxis(sliderAngle, rotationAxis); // turn around x axis
            transform.Rotate(rotationEulers);
        }
    }
    public float GetSliderPercent() {
        return ((sliderAngle-(-45))*(75-0)/(30-(-45))+0)/75;
    }
}