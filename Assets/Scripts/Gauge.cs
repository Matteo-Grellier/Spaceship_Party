using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public float fuel = 1f;
<<<<<<< HEAD
    private float gaugeHeight;
=======
    private float jaugeHeight;
>>>>>>> 1131bf1 (:lipstick: | the 3d gauge is filled according to the fuel oil (gauge not finished))
    public GameObject cylinder;
    private Vector3 saveSize;
    private Vector3 savePos;

    // Start is called before the first frame update
    void Start()
    {
        saveSize = cylinder.transform.localScale;
<<<<<<< HEAD
        gaugeHeight = saveSize.y;
        cylinder.transform.localScale = new Vector3(saveSize.x, gaugeHeight * fuel, saveSize.z);
=======
        jaugeHeight = saveSize.y;
        savePos = cylinder.transform.position;
        cylinder.transform.localScale = new Vector3(saveSize.x, jaugeHeight * fuel, saveSize.z);
        // cylinder.transform.position = new Vector3(savePos.x, 1+saveSize.y+0.15f, savePos.z);
        // cylinder.transform.position = new Vector3(savePos.x, savePos.y, savePos.z);
>>>>>>> 1131bf1 (:lipstick: | the 3d gauge is filled according to the fuel oil (gauge not finished))
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        cylinder.transform.localScale =  Vector3.Lerp(saveSize, new Vector3(saveSize.x, gaugeHeight * fuel, saveSize.z), 0.04f);
=======
        cylinder.transform.localScale =  Vector3.Lerp(saveSize, new Vector3(saveSize.x, jaugeHeight * fuel, saveSize.z), 0.05f);
        // cylinder.transform.position = new Vector3(savePos.x, savePos.y, savePos.z);
>>>>>>> 1131bf1 (:lipstick: | the 3d gauge is filled according to the fuel oil (gauge not finished))
        saveSize = cylinder.transform.localScale;
    }
}
