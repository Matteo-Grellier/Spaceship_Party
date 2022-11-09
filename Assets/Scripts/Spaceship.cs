using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float maxSpeed;
    private int moveSpeed = 0;
    private int turnRotation = 0;
    public Transform orientation;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        int changeTurnRotationStatus = 0;
        int changeSpeedStatus = 0;
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
        }
        if (Input.GetKey("d"))
        {
            changeTurnRotationStatus = 1;
        }
        ChangeSpeed(changeSpeedStatus);
        ChangeTurnRotationStatus(changeTurnRotationStatus);
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
        Debug.Log(moveSpeed);
    }

    private void ChangeTurnRotationStatus(int changeTurnRotationStatus)
    {
        if ((turnRotation + changeTurnRotationStatus) > 70 || (turnRotation + changeTurnRotationStatus) < -70)
        {
            Debug.Log("Vous avez atteint les limites du gouvernail !");
        }
        else
        {
            turnRotation += changeTurnRotationStatus;
        }
        Debug.Log(turnRotation);
    }

    private void MovePlayer(int moveSpeed)
    {
        rb.AddForce(0f, 0f, maxSpeed * moveSpeed, ForceMode.Force);
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
