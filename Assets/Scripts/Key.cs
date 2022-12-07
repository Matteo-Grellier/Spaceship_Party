using UnityEngine;

public class Key : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    private bool startStop = false;
    public float angleOpenKey = -75f;

    private void RotateKeyLeft()
    {
        Quaternion desiredRotation = Quaternion.Euler(0f, angleOpenKey, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
    private void RotateKeyRight()
    {
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }

    void OnMouseDown()
    {
        startStop = !startStop;
    }

    private void FixedUpdate()
    {
        if (startStop) {
            RotateKeyLeft();
        } else {
            RotateKeyRight();
        }
    }
}
