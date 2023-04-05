using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    public Spaceship spaceship;
    
    public Slider GaugeUI;

    void FixedUpdate() {
        GaugeUI.value = GameObject.FindWithTag("spaceship")?.GetComponent<Spaceship>().GetFuelLevel();
    }
}
