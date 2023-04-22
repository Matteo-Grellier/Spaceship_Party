using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    public Spaceship spaceship;
    
    public Slider GaugeUI;

    void FixedUpdate() {

        if(!spaceship && GameManager.instance.localPlayer != null)
        {
            spaceship = GameManager.instance.localPlayer.GetComponent<Spaceship>();
            return;
        }

        if (spaceship != null)
            GaugeUI.value = spaceship.GetFuelLevel();
    }
}
