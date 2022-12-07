using UnityEngine;

public class Slider : MonoBehaviour
{
    private float mZCoord;
    private float mXCoord;

    public float smoothSpeed = 0.125f;
    private float sliderAngle = 0f;

    void Start() {
        RotateSlider();
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mXCoord = Camera.main.WorldToScreenPoint(transform.position).x;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector3(mXCoord, -mousePoint.y, mZCoord));
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = GetMouseWorldPos();
        sliderAngle = mousePos.x * 10;
        RotateSlider();
    }

    private void RotateSlider() {
        Quaternion desiredRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, sliderAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}