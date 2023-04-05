using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public string name;
    public bool isUsed = false;
    private Spaceship spaceship;

    private int boostDelay = 3;
    private int shieldDelay = 20;

    public void Use() 
    {

        spaceship = GameObject.FindWithTag("spaceship").GetComponent<Spaceship>();

        switch (name)
        {
            case "Rocket":
                Debug.Log(name + " launched!");
                break;
            case "IEM":
                Debug.Log(name + " exploded!");
                break;
            case "Refuel":
                spaceship.FullyRechargeGauge();
                break;
            case "Boost":
                StartCoroutine(BoostForAGivenTime(boostDelay));
                break;
            case "Shield":
                StartCoroutine(ShieldIsActivatedForAGivenTime(shieldDelay));
                break;
            default:
                break;
        }
        isUsed = true;
    }

    private IEnumerator BoostForAGivenTime(int seconds)
    {
        spaceship.canBoost = true;
        yield return new WaitForSeconds(seconds);
        spaceship.canBoost = false;
    }

    private IEnumerator ShieldIsActivatedForAGivenTime(int seconds)
    {
        spaceship.shieldActivated = true;
        yield return new WaitForSeconds(seconds);
        spaceship.shieldActivated = false;
    }
}
