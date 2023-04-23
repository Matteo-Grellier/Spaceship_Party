using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("spaceship") && other is Collider)
        {
            if (other.isTrigger) return; // if its the sphere trigger of the spaceship, does nothing

            GameManager.instance.winner = other.gameObject.GetComponent<Spaceship>();
        }
    }
}
