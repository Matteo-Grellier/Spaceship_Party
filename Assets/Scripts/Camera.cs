using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private Vector3 offset, targetPreviousPosition;

    private void Start()
    {
        offset = transform.position - target.position;
        targetPreviousPosition = target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetMoveDirection = target.position - targetPreviousPosition;
        Vector3 desiredPosition = target.position - targetMoveDirection + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(target.position);
        transform.position = smoothedPosition;
        targetPreviousPosition = target.position;
    }
}
