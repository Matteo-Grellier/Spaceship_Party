using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public float fuel = 1f;
    private float gaugeHeight;
    public GameObject cylinder;
    private Vector3 saveSize;
    private Vector3 savePos;

    // Start is called before the first frame update
    void Start()
    {
        saveSize = cylinder.transform.localScale;

        gaugeHeight = saveSize.y;
        cylinder.transform.localScale = new Vector3(saveSize.x, gaugeHeight * fuel, saveSize.z);

    }
    // Update is called once per frame
    void Update()
    {
        cylinder.transform.localScale =  Vector3.Lerp(saveSize, new Vector3(saveSize.x, gaugeHeight * fuel, saveSize.z), 0.04f);

        saveSize = cylinder.transform.localScale;
    }
}
