using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Rigidbody rb;
    public Slider slider;
    public float multiplierSpeed;
    public float smoothSpeed = 0.125f;
    private float turnRotation;
    private float turnAngle;
    private float oldAccelerationValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        turnRotation = transform.eulerAngles.y;
        turnAngle = transform.eulerAngles.x;
    }

    private void FixedUpdate()
    {
        int changeTurnRotationStatus = 0;
        turnAngle = 0;
        if (Input.GetKey("a"))
        {
            changeTurnRotationStatus = -1;
            turnAngle = 15;
        }
        if (Input.GetKey("d"))
        {
            changeTurnRotationStatus = 1;
            turnAngle = -15;
        }
        turnRotation += changeTurnRotationStatus;
        MovePlayer(slider.GetValue());
        oldAccelerationValue = slider.GetValue();
    }
    
    private void MovePlayer(float moveSpeed)
    {
        moveSpeed -= oldAccelerationValue;
        rb.AddRelativeForce(0f, 0f, multiplierSpeed * moveSpeed, ForceMode.Force);
        Quaternion desiredRotation = Quaternion.Euler(0f, turnAngle, turnRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}
