using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RechargeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Spaceship spaceship;

    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!spaceship)
        {
            spaceship = GameObject.FindWithTag("spaceship")?.GetComponent<Spaceship>();
            return;
        }

        if (isPressed)
        {
            spaceship?.RechargeGauge();
        }

    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
