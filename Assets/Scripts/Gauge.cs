using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    public Spaceship spaceship;
    
    public Slider GaugeUI;

    void FixedUpdate() {

        if(!spaceship)
        {
            spaceship = GameObject.FindWithTag("spaceship").GetComponent<Spaceship>();
            return;
        }

        GaugeUI.value = spaceship.GetFuelLevel();
    }
}
