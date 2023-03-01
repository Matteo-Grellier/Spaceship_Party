using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuse : MonoBehaviour
{
    private  Vector3 targetAngles;
    public void Rotation(){
        transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,180f));
    }
}
