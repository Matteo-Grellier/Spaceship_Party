using UnityEngine;

public class Slider : MonoBehaviour
{
    public float smoothSpeed = 100f;
    public float sliderAngle = 0f;
    public bool canBeMove = true;

    void OnMouseDrag() {
        if(canBeMove){
            RotateSlider();
        }
    }

    private void RotateSlider() 
    {
        sliderAngle += Input.GetAxis("Mouse Y") * smoothSpeed * Time.deltaTime;
        sliderAngle = Mathf.Clamp(sliderAngle, -0.01f, 0.01f);
        Debug.Log(sliderAngle);
        transform.localPosition += new Vector3(sliderAngle, 0, 0);

        //transform.localPosition += new Vector3(0, 0, sliderAngle);
        //transform.rotation = Quaternion.AngleAxis(sliderAngle, Vector3.right); // turn around x axis
        //transform.Rotate(new Vector3(0, 90, 0));
    }

    public float GetSliderPercent() {
        return ((sliderAngle-(-45))*(75-0)/(30-(-45))+0)/75;
    }
}