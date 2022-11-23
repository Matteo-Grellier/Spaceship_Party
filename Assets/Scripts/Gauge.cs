using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public float fuel = 1f;
    private float jaugeHeight;
    public GameObject cylinder;
    private Vector3 saveSize;
    private Vector3 savePos;

    // Start is called before the first frame update
    void Start()
    {
        saveSize = cylinder.transform.localScale;
        jaugeHeight = saveSize.y;
        savePos = cylinder.transform.position;
        cylinder.transform.localScale = new Vector3(saveSize.x, jaugeHeight * fuel, saveSize.z);
        // cylinder.transform.position = new Vector3(savePos.x, 1+saveSize.y+0.15f, savePos.z);
        // cylinder.transform.position = new Vector3(savePos.x, savePos.y, savePos.z);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        cylinder.transform.localScale =  Vector3.Lerp(saveSize, new Vector3(saveSize.x, jaugeHeight * fuel, saveSize.z), 0.05f);
        // cylinder.transform.position = new Vector3(savePos.x, savePos.y, savePos.z);
        saveSize = cylinder.transform.localScale;
    }
}
