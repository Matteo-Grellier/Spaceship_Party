using UnityEngine;

public class Rudder : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    private float sliderAngle = 0f;
    private void RotateSlider() {
        Quaternion desiredRotation = Quaternion.Euler(0, 0, sliderAngle);
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, desiredRotation, smoothSpeed);
    }
    void OnMouseDrag()
    {
        sliderAngle = Input.mousePosition.x;
        RotateSlider();
    }

}