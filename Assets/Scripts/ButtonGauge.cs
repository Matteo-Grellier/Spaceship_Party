using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGauge : MonoBehaviour
{
    // Start is called before the first frame update
    public Gauge gauge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        gauge.fuel = 1f;
    }
}
