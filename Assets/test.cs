using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, -10);
    }
}
