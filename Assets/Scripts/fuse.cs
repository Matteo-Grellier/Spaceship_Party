using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuse : MonoBehaviour
{
    private  Vector3 targetAngles;
    private bool state = true;
    public void Rotation() {
        state = !state;
        transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,180f));
    }

    public bool GetState() {
        return state;
    }

    public void SetState(bool newState) {
        state = newState;
    }
}
