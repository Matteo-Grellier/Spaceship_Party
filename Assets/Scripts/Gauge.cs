using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    public SliderAverage sliders;
    public float fuel = 1f;
    public float fuelMultiplier = 0.001f;
    public Slider GaugeUI;

    private void FuelConsumer() {
        float slidersPower = sliders.getAverage();
        if (fuel > 0.0) {
            sliders.setInteractable(true);
            fuel = fuel - (slidersPower * fuelMultiplier);
        } else {
            fuel = 0f;
            sliders.setInteractable(false);
            sliders.setValue(0f);
        }
    }

    public void RechargeFuel()
    {
        fuel += 0.01f;
    }

    void FixedUpdate() {
        FuelConsumer();
        GaugeUI.value = fuel;
    }
}
