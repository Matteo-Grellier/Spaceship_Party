using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Rigidbody rb;
    public float maxSpeed;
    public float smoothSpeed = 0.125f;
    private int moveSpeed = 0;
    private float turnRotation;
    private float turnAngle;

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
        int changeSpeedStatus = 0;
        turnAngle = 0;
        if (Input.GetKey("w"))
        {
            changeSpeedStatus = 1;
        }
        if (Input.GetKey("s"))
        {
            changeSpeedStatus = -1;
        }
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
        ChangeSpeed(changeSpeedStatus);
        MaxSpeedControl(moveSpeed);
        MovePlayer(moveSpeed);
    }

    private void ChangeSpeed(int changeSpeedStatus)
    {
        if ((moveSpeed + changeSpeedStatus) > 10 || (moveSpeed + changeSpeedStatus) < 0)
        {
            Debug.Log("Vous avez atteint les limites des réacteurs !");
        } else
        {
            moveSpeed += changeSpeedStatus;
        }
    }

    private void MovePlayer(int moveSpeed)
    {
        rb.AddRelativeForce(0f, maxSpeed * moveSpeed, 0f, ForceMode.Force);
        Quaternion desiredRotation = Quaternion.Euler(turnAngle, turnRotation, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }

    private void MaxSpeedControl(int moveSpeed)
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
