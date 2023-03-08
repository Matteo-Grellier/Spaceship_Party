using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauge : MonoBehaviour
{
    public float fuel = 1f;
    public Slider GaugeUI;

    private void Update()
    {
        GaugeUI.value = fuel;
    }
}
