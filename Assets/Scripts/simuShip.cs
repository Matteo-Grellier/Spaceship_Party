using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simuShip : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(0f, 0f, 5f, ForceMode.Force);
    }
}
