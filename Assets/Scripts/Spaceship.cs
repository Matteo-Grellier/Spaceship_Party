using UnityEngine;
using Mirror;

public class Spaceship : NetworkBehaviour
{
    private Rigidbody rb;
    private Rudder rudder;
    //private Slider slider;
    public float multiplierSpeed;
    public float smoothSpeed = 0.125f;
    private float turnRotation;
    private float turnAngle;
    private float oldAccelerationValue;
    private float oldAngleValue;

    private void Awake()
    {
        //slider = GameObject.Find("poignee2").GetComponent<Slider>();
        rudder = GameObject.Find("gouvernail").GetComponent<Rudder>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        turnRotation = transform.eulerAngles.y;
        turnAngle = transform.eulerAngles.x;
    }

    private void FixedUpdate()
    {
      if (isLocalPlayer){
        
        turnRotation = rudder.GetValue();
        turnAngle = 0;
        if (turnRotation > oldAngleValue)
        {
            turnAngle = 15;
        } else
        {
            turnAngle = -15;
        }
        //MovePlayer(slider.GetSliderPercent());
        //oldAccelerationValue = slider.GetSliderPercent();
        oldAngleValue = turnRotation;
      }
      else
      {
        transform.Find("Camera").gameObject.SetActive(false);
      }
    }
    private void MovePlayer(float moveSpeed)
    {
        // moveSpeed -= oldAccelerationValue;
        rb.AddRelativeForce(0f, multiplierSpeed * moveSpeed, 0f, ForceMode.Force);
        Quaternion desiredRotation = Quaternion.Euler(90f, turnRotation, turnAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}
