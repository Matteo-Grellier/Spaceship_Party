using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    public Spaceship spaceship;
    public SliderAverage sliders;
    public float fuel = 1f;
    public float fuelMultiplier = 0.001f;
    public Slider GaugeUI;

    private void FuelConsumer() {
        float slidersPower = sliders.GetAverage();
        if (fuel > 0.0) {
            spaceship = GameObject.FindWithTag("spaceship").GetComponent<Spaceship>();
            if (!spaceship.GetLeftReactorBroke() && !spaceship.GetRightReactorBroke()) {
                sliders.SetInteractable(true);
            } else if (spaceship.GetLeftReactorBroke() && !spaceship.GetRightReactorBroke()) {
                sliders.GetRightSlider().interactable = true;
            } else if (spaceship.GetRightReactorBroke() && !spaceship.GetLeftReactorBroke()) {
                sliders.GetLeftSlider().interactable = true;
            }
            fuel = fuel - (slidersPower * fuelMultiplier);
        } else {
            fuel = 0f;
            sliders.SetInteractable(false);
            sliders.SetValue(0f);
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
