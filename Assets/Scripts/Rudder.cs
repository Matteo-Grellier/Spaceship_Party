using UnityEngine;

public class Rudder : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    private float sliderAngle = 0f;
    private void RotateSlider() {
        Quaternion desiredRotation = Quaternion.Euler(0, sliderAngle, 0);
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, desiredRotation, smoothSpeed);
    }
    public float GetValue() {
        return sliderAngle;
    }
    void OnMouseDrag()
    {
        sliderAngle = Input.mousePosition.x;
        RotateSlider();
    }
}