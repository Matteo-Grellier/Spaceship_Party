using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    //public Slider slider;
    public float fuel = 1f;
    private float gaugeHeight;
    public GameObject cylinder;
    private Vector3 saveSize;
    public float fuelMultiplier = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        saveSize = cylinder.transform.localScale;

        gaugeHeight = saveSize.y;
        cylinder.transform.localScale = new Vector3(saveSize.x, gaugeHeight * fuel, saveSize.z);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        cylinder.transform.localScale = new Vector3(saveSize.x, gaugeHeight * fuel, saveSize.z);
        saveSize = cylinder.transform.localScale;
        FuelConsumer();
    }

    private void FuelConsumer()
    {
        //float sliderPower = slider.GetSliderPercent();
        if(fuel > 0.0){
            //slider.canBeMove = true;
            //fuel = fuel - (sliderPower * fuelMultiplier);
        } else {
            fuel = 0f;
            //slider.canBeMove = false;
            Vector3 rotationAxis;
            Vector3 rotationEulers;
            //slider.sliderAngle = -36f;
            rotationAxis = Vector3.right;
            rotationEulers = new Vector3(0, 90, 0);
            //slider.transform.rotation = Quaternion.AngleAxis(slider.sliderAngle, rotationAxis);
            //slider.transform.Rotate(rotationEulers);
        }
    }
}
