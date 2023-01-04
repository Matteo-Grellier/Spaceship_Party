using UnityEngine;

public class Rudder : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    private float sliderAngle = 0f;
    private float mZCoord;
    private float mXCoord;
    private void RotateSlider() {
        // Quaternion desiredRotation = Quaternion.Euler(sliderAngle,transform.eulerAngles.y, transform.eulerAngles.x);
        Quaternion desiredRotation = Quaternion.Euler(transform.rotation.x, sliderAngle, transform.rotation.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
    void OnMouseDrag()
    {
        sliderAngle = Input.mousePosition.x;
        RotateSlider();
    }

}