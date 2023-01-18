using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Rigidbody rb;
    public Slider slider;
    public Rudder rudder;
    public float multiplierSpeed;
    public float smoothSpeed = 0.125f;
    private float turnRotation;
    private float turnAngle;
    private float oldAccelerationValue;
    private float oldAngleValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        turnRotation = transform.eulerAngles.y;
        turnAngle = transform.eulerAngles.x;
    }

    private void FixedUpdate()
    {
        turnRotation = rudder.GetValue();
        turnAngle = 0;
        if (turnRotation > oldAngleValue)
        {
            turnAngle = 15;
        } else
        {
            turnAngle = -15;
        }
        MovePlayer(slider.GetValue());
        oldAccelerationValue = slider.GetValue();
        oldAngleValue = turnRotation;
    }
    
    private void MovePlayer(float moveSpeed)
    {
        // moveSpeed -= oldAccelerationValue;
        rb.AddRelativeForce(0f, 0f, multiplierSpeed * moveSpeed, ForceMode.Force);
        Quaternion desiredRotation = Quaternion.Euler(0f, turnRotation, turnAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}
