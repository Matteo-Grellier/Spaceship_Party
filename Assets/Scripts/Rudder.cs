using UnityEngine;

public class Rudder : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private float rotationMultiplier = 0.2f; 
    private float sliderAngle = 0f;

    private float clickPosition;

    private void OnMouseDown() 
    {
        clickPosition = Input.mousePosition.x;
    }

    void OnMouseDrag()
    {
        sliderAngle += (Input.mousePosition.x - clickPosition) * rotationMultiplier; 
        clickPosition = Input.mousePosition.x;

        RotateSlider();
    }

    private void RotateSlider()
    {
        Quaternion desiredRotation = Quaternion.Euler(0, sliderAngle, 0);
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, desiredRotation, smoothSpeed);
    }

    public float GetValue() 
    {
        return sliderAngle;
    }
}